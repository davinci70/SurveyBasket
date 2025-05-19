using Hangfire;

namespace SurveyBasket.Services.Service;

public class PollService(ApplicationDbContext context, INotificationService notificationService) : IPollService
{
    private readonly ApplicationDbContext _context = context;
    private readonly INotificationService _notificationService = notificationService;

    public async Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default)
    {
        var isTitleExists = await _context.Polls.AnyAsync(x  => x.Title == request.Title, cancellationToken: cancellationToken);

        if (isTitleExists)
            return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

        var poll = request.Adapt<Poll>();

        await _context.AddAsync(poll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(poll.Adapt<PollResponse>());
    }

    public async Task<Result> DeleteAsync(int Id, CancellationToken cancellationToken = default)
    {
        var Poll = await _context.Polls.FindAsync(Id, cancellationToken);

        if (Poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        _context.Remove(Poll);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        return poll is not null ? Result.Success(poll.Adapt<PollResponse>()) : Result.Failure<PollResponse>(PollErrors.PollNotFound);
    }

    public async Task<IEnumerable<PollResponse>> GetAllAsync(CancellationToken cancellationToken = default) => 
        await _context.Polls
        .ProjectToType<PollResponse>()
        .AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<PollResponse>> GetCurrentAsync(CancellationToken cancellationToken = default) =>
        await _context.Polls
        .Where(x => x.IsPublished && DateOnly.FromDateTime(DateTime.UtcNow) >= x.StartsAt && DateOnly.FromDateTime(DateTime.UtcNow) <= x.EndsAt)
        .ProjectToType<PollResponse>()
        .AsNoTracking()
        .ToListAsync();

    public async Task<Result> UpdateAsync(int Id, PollRequest request, CancellationToken cancellationToken = default)
    {
        var isTitleExists = await _context.Polls.AnyAsync(x => x.Title == request.Title && x.Id != Id, cancellationToken: cancellationToken);

        if (isTitleExists)
            return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

        var currentPoll = await _context.Polls.FindAsync(Id, cancellationToken);

        if (currentPoll is null)
            return Result.Failure(PollErrors.PollNotFound);

        currentPoll = request.Adapt(currentPoll);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> TogglePublishStatusAsync(int Id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(Id, cancellationToken);

        if (poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        poll.IsPublished = !poll.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        if (poll.IsPublished && poll.StartsAt == DateOnly.FromDateTime(DateTime.UtcNow))
        {
            BackgroundJob.Enqueue(() => _notificationService.SendNewPollNotification(poll.Id));
        }

        return Result.Success();
    }
}

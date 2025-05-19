using Microsoft.EntityFrameworkCore;
using SurveyBasket.Contracts.Questions;
using SurveyBasket.Contracts.Votes;
using SurveyBasket.Entities;

namespace SurveyBasket.Services.Service;

public class VoteService(ApplicationDbContext context) : IVoteService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result> AddAsync(int PollId, string UserId, VoteRequest request, CancellationToken cancellationToken)
    {
        var hasVote = await _context.Votes.AnyAsync(x => x.PollId == PollId && x.UserId == UserId);

        if (hasVote)
            return Result.Failure(VoteErrors.DublicatedVote);
        var IsPollExists = await _context.Polls.AnyAsync(x => x.Id == PollId && x.IsPublished && DateOnly.FromDateTime(DateTime.UtcNow) >= x.StartsAt && DateOnly.FromDateTime(DateTime.UtcNow) <= x.EndsAt, cancellationToken);

        if (!IsPollExists)
            return Result.Failure(PollErrors.PollNotFound);

        var availableQuestions = await _context.Questions
            .Where(x => x.PollId == PollId && x.IsActive)
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        if (!request.Answers.Select(x => x.QuestionId).SequenceEqual(availableQuestions))
            return Result.Failure(VoteErrors.InvalidQuestions);

        var vote = new Vote
        {
            PollId = PollId,
            UserId = UserId,
            VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()
        };

        await _context.AddAsync(vote);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(vote);
    }
}

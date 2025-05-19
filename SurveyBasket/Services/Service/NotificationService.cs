using Microsoft.AspNetCore.Identity;
using SurveyBasket.Helpers;

namespace SurveyBasket.Services.Service;

public class NotificationService(
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    IEmailService emailService,
    IHttpContextAccessor httpContextAccessor) : INotificationService
{
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task SendNewPollNotification(int? pollId = null)
    {
        IEnumerable<Poll> polls = [];

        if (pollId.HasValue)
        {
            var poll = await _context.Polls.SingleOrDefaultAsync(x => x.Id == pollId && x.IsPublished);

            polls = [poll!];
        }
        else
        {
            polls = await _context.Polls
                .Where(x => x.IsPublished && x.StartsAt == DateOnly.FromDateTime(DateTime.UtcNow))
                .AsNoTracking()
                .ToListAsync();
        }

        var users = await _userManager.GetUsersInRoleAsync(DefaultRoles.Member);

        var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin;

        foreach (var poll  in polls)
        {
            foreach (var user in users)
            {
                var placeHolders = new Dictionary<string, string>
                {
                    {"{{name}}", user.FirstName},
                    {"{{pollTill}}", poll.Title},
                    {"{{endDate}}", poll.EndsAt.ToString()},
                    {"{{url}}", $"{origin}/polls/start/{poll.Id}"}
                };

                var body = EmailBodyBuilder.GenerateEmailBody("pollNotification", placeHolders);

                await _emailService.SendEmailAsync(user.Email!, $"Survey Basket: New Poll - {poll.Title}", body);
            }
        }
    }
}

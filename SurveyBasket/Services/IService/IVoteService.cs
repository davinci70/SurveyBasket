using SurveyBasket.Contracts.Votes;

namespace SurveyBasket.Services.IService;

public interface IVoteService
{
    Task<Result> AddAsync(int PollId, string UserId, VoteRequest request, CancellationToken cancellationToken);
}

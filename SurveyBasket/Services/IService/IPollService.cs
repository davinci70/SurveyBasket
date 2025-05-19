namespace SurveyBasket.Services.IService;

public interface IPollService
{
    Task<IEnumerable<PollResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<PollResponse>> GetCurrentAsync(CancellationToken cancellationToken = default);
    Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int Id, PollRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int Id, CancellationToken cancellationToken = default);
    Task<Result> TogglePublishStatusAsync(int Id, CancellationToken cancellationToken = default);
}

namespace SurveyBasket.Services.IService;

public interface IAuthService
{
    Task<Result<AuthResponse>> getTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> getRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
    Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request);
    Task<Result> SendPasswordResetTokenAsync(string email);
    Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
}

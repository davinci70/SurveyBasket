namespace SurveyBasket.Errors;

public static class UserErrors
{
    public static readonly Error UserNotFound = 
        new("User.UserNotFound", "User is not found", StatusCodes.Status404NotFound);
    
    public static readonly Error InvalidCredentials = 
        new("User.InvalidCredentials", "Invalid Email/Password", StatusCodes.Status401Unauthorized);
    
    public static readonly Error DisabledUser = 
        new("User.DisabledUser", "Disabled user, please contact your admin", StatusCodes.Status401Unauthorized);
    
    public static readonly Error LockedUser = 
        new("User.LockedUser", "Locked user, please contact your admin", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
        new("User.InvalidJwtToken", "Invalid Jwt token", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidRefreshToken =
        new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status400BadRequest);
    
    public static readonly Error EmailNotConfirmed =
        new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);
    
    public static readonly Error DublicatedEmail =
        new("User.DublicatedEmail", "this email is already used by another user", StatusCodes.Status409Conflict);
    
    public static readonly Error InvalidCode =
        new("User.InvalidCode", "Invalid code", StatusCodes.Status401Unauthorized);
    
    public static readonly Error EmailAlreadyConfirmed =
        new("User.EmailAlreadyConfirmed", "Email is already confirmed", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidRoles =
        new("User.InvalidRoles", "Invalid roles", StatusCodes.Status400BadRequest);
}

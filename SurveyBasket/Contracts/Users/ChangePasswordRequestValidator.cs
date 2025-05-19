namespace SurveyBasket.Contracts.Users;

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty();

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Matches("^[a-zA-Z0-9]{8,}$\r\n")
            .WithMessage("Password should be at least 8 characters")
            .NotEqual(x => x.CurrentPassword)
            .WithMessage("New password cannot be same as current password");
    }
}

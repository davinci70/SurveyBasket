namespace SurveyBasket.Contracts.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();
        
        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.Roles)
            .NotEmpty()
            .Must(x => x.Distinct().Count() == x.Count())
            .WithMessage("You cannot add dublicated roles for the same user")
            .When(x => x.Roles != null);
    }
}

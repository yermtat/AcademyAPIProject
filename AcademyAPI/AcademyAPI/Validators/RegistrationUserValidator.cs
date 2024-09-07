using AcademyAPI.Data.Models.Auth;
using FluentValidation;

namespace AcademyAPI.Validators;

public class RegistrationUserValidator : AbstractValidator<RegisterUser>
{

	public RegistrationUserValidator()
	{
		RuleFor(x => x.Username)
				.NotEmpty()
				.WithMessage("Username is required")
				.Matches(RegexPatterns.usernamePattern)
				.When(x => x.Username != null);

		RuleFor(x => x.Password)
				.NotEmpty()
				.WithMessage("Password is required")
				.Matches(RegexPatterns.passwordPattern)
				.When(x => x.Password != null);

		RuleFor(x => x.Email)
			.NotEmpty()
			.WithMessage("Email is required")
			.EmailAddress()
			.WithMessage("Valid email is required");


		RuleFor(x => x.ConfirmPassword)
			.NotEmpty()
			.WithMessage("Password confirmation is required")
			.Equal(x => x.Password)
			.WithMessage("Password doesn't match");
    }

}

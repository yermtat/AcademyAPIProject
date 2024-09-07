﻿using AcademyAPI.Data.Models.Auth;
using FluentValidation;

namespace AcademyAPI.Validators;

public class LoginUserValidator : AbstractValidator<LoginUser>
{
	public LoginUserValidator()
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
	}
}

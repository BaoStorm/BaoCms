using System;
using System.Collections.Generic;
using System.Text;
using BaoCMS.Domain.Users.Commands;
using BaoCMS.Domain.Users.Rules;
using FluentValidation;

namespace BaoCMS.Domain.Users.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        private readonly IUserRules _userRules;

        public CreateUserValidator(IUserRules userRules)
        {
            _userRules = userRules;

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email not valid.")
                .Length(1, 250).WithMessage("Email maximum length is 250 characters.")
                .Must(HaveUniqueEmail).WithMessage("Email already exists.");

            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Length(1, 250).WithMessage("UserName maximum length is 250 characters.")
                .Must(HaveUniqueUserName).WithMessage("UserName already exists.");
        }

        private bool HaveUniqueEmail(string email)
        {
            return _userRules.IsUserEmailUnique(email);
        }

        private bool HaveUniqueUserName(string userName)
        {
            return _userRules.IsUserNameUnique(userName);
        }
    }
}

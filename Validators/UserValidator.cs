using FluentValidation;
using bloggin_plataform_api.DTOs.User;

namespace bloggin_plataform_api.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotNull().NotEmpty().WithMessage("The username is required.");

            RuleFor(user => user.EmailAddress)
                .NotNull().NotEmpty().WithMessage("The email address is required.")
                .EmailAddress().WithMessage("The email address format is invalid.");

            RuleFor(user => user.Password)
                .NotNull().NotEmpty().WithMessage("The password is required.")
                .MinimumLength(8).WithMessage("The password must be 8 characters or longer.");
        }
    }
}
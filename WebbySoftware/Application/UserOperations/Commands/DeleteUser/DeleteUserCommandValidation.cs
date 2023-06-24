using FluentValidation;

namespace WebbySoftware.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage(ErrorMessages.requireID)
                .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
        }
    }
}
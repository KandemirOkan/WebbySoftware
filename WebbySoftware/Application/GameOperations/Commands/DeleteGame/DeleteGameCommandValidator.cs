using FluentValidation;

namespace WebbySoftware.Application.GameOperations.Commands.DeleteGame
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameCommandValidator()
        {
            RuleFor(x => x.GameID)
                .NotEmpty().WithMessage(ErrorMessages.requireID)
                .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
        }
    }
}
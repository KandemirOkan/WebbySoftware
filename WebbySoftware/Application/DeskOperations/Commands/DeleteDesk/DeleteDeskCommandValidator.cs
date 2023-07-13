using FluentValidation;

namespace WebbySoftware.Application.DeskOperations.Commands.DeleteDesk
{
    public class DeleteDeskCommandValidator : AbstractValidator<DeleteDeskCommand>
    {
        public DeleteDeskCommandValidator()
        {
            RuleFor(x => x.DeskID)
                .NotEmpty().WithMessage(ErrorMessages.requireID)
                .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
        }
    }
}
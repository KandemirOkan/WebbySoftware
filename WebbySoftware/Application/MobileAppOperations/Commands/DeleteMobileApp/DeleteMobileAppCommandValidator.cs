using FluentValidation;

namespace WebbySoftware.Application.MobileAppOperations.Commands.DeleteMobileApp
{
    public class DeleteMobileAppCommandValidator : AbstractValidator<DeleteMobileAppCommand>
    {
        public DeleteMobileAppCommandValidator()
        {
            RuleFor(x => x.MobileAppID)
                .NotEmpty().WithMessage(ErrorMessages.requireID)
                .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
        }
    }
}
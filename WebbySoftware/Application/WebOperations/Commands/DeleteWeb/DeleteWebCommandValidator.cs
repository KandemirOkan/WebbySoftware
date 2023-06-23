using FluentValidation;

namespace WebbySoftware.Application.WebOperations.Commands.DeleteWeb
{
    public class DeleteWebAppCommandValidator : AbstractValidator<DeleteWebAppCommand>
    {
        public DeleteWebAppCommandValidator()
        {
            RuleFor(x => x.WebAppID)
                .NotEmpty().WithMessage(ErrorMessages.requireID)
                .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
        }
    }
}
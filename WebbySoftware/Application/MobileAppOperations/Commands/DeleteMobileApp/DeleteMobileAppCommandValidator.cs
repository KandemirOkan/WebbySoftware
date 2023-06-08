using FluentValidation;

namespace WebbySoftware.Application.MobileAppOperations.Commands.DeleteMobileApp
{
    public class DeleteMobileAppCommandValidator : AbstractValidator<DeleteMobileAppCommand>
    {
        public DeleteMobileAppCommandValidator()
        {
            RuleFor(x=>x.MobileAppID).GreaterThan(0);
        }
    }
}
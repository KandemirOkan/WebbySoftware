using FluentValidation;

namespace WebbySoftware.Application.MobileAppOperations.Queries
{
    public class GetMobileAppByIdValidator: AbstractValidator<GetMobileAppByID>
    {
        public GetMobileAppByIdValidator()
        {
            RuleFor(x=>x.MobileAppID).GreaterThan(0);
        }
    }
}
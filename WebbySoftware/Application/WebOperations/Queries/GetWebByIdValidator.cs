using FluentValidation;

namespace WebbySoftware.Application.WebOperations.Queries
{
    public class GetWebByIdValidator: AbstractValidator<GetWebByID>
    {
        public GetWebByIdValidator()
        {
            RuleFor(x=>x.WebAppID).GreaterThan(0);
        }
    }
}
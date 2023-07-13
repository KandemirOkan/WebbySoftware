using FluentValidation;

namespace WebbySoftware.Application.DeskOperations.Queries
{
    public class GetDeskByIdValidator: AbstractValidator<GetDeskById>
    {
        public GetDeskByIdValidator()
        {
            RuleFor(x=>x.DeskID).GreaterThan(0);
        }
    }
}
using FluentValidation;

namespace WebbySoftware.Application.GameOperations.Queries
{
    public class GetGameByIdValidator: AbstractValidator<GetGameByID>
    {
        public GetGameByIdValidator()
        {
            RuleFor(x=>x.GameID).GreaterThan(0);
        }
    }
}
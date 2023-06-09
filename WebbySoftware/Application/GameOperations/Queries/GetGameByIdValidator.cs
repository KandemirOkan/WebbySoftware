using FluentValidation;

namespace WebbySoftware.Application.GameOperations.Queries
{
    public class GetGameByIdValidator: AbstractValidator<GetGameById>
    {
        public GetGameByIdValidator()
        {
            RuleFor(x=>x.GameID).GreaterThan(0);
        }
    }
}
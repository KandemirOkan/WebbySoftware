using FluentValidation;

namespace WebbySoftware.Application.GameOperations.Commands.DeleteGame
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameCommandValidator()
        {
            RuleFor(x=>x.GameID).GreaterThan(0);
        }
    }
}
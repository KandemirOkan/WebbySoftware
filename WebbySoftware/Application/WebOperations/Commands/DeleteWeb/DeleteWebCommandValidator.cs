using FluentValidation;

namespace WebbySoftware.Application.WebOperations.Commands.DeleteWeb
{
    public class DeleteWebAppCommandValidator : AbstractValidator<DeleteWebAppCommand>
    {
        public DeleteWebAppCommandValidator()
        {
            RuleFor(x=>x.WebAppID).GreaterThan(0);
        }
    }
}
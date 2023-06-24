using FluentValidation;

namespace WebbySoftware.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>{

        public CreateUserCommandValidator(){

            {      
                RuleFor(x => x.Model.Name)
                    .NotEmpty().WithMessage(ErrorMessages.uNameError)
                    .MaximumLength(20);
                
                RuleFor(x => x.Model.Surname)
                    .NotEmpty().WithMessage(ErrorMessages.uNameError)
                    .MaximumLength(20);

                RuleFor(x=> x.Model.GithubLink)
                    .MaximumLength(50);

                RuleFor(x=> x.Model.LinkedINLink)
                    .MaximumLength(100);
            }
        }
    }
}
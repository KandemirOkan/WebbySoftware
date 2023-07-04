using FluentValidation;


namespace WebbySoftware.Application.UserOperations.Commands.UpdateUser{

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>{

        public UpdateUserCommandValidator(){

            {
                RuleFor(x => x.UserID)
                    .NotEmpty().WithMessage(ErrorMessages.requireID)
                    .Must(ValidationUtilities.IsIntegerValid).WithMessage(ErrorMessages.invalidID)
                    .GreaterThan(0).WithMessage(ErrorMessages.zeroID);
                    
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
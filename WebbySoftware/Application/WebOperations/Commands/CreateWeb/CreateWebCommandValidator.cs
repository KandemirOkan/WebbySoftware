using FluentValidation;


namespace WebbySoftware.Application.WebOperations.Commands.CreateWebApp{

    public class CreateWebAppCommandValidator : AbstractValidator<CreateWebAppCommand>{

        public CreateWebAppCommandValidator(){

            RuleFor(x => x.Model.ProjectName)
                .NotEmpty().WithMessage(ErrorMessages.pNameError)
                .MaximumLength(50);
            
            RuleFor(x => x.Model.ProjectDescription)
                .NotEmpty().WithMessage(ErrorMessages.pDescError)
                .MaximumLength(300);
            
            RuleFor(x => x.Model.ProjectGitLink)
                .NotEmpty().WithMessage(ErrorMessages.pGitError)
                .MaximumLength(65);
            
            RuleFor(x => x.Model.Thumbnails)
                .Must(list => list.Count <= 5).WithMessage(ErrorMessages.ThumbError);
                
            RuleFor(x=> x.Model.ProjectWebpage).MaximumLength(100);
        }
    }
}
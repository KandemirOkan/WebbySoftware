using FluentValidation;


namespace WebbySoftware.Application.DeskOperations.Commands.CreateDesk{

    public class CreateDeskCommandValidator : AbstractValidator<CreateDeskCommand>{

        public CreateDeskCommandValidator(){

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
        }
    }
}
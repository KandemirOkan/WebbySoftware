using FluentValidation;


namespace WebbySoftware.Application.WebOperations.Commands.CreateWebApp{

    public class CreateWebAppCommandValidator : AbstractValidator<CreateWebAppCommand>{

        public CreateWebAppCommandValidator(){

            RuleFor(x => x.Model.ProjectName).MaximumLength(50);
            RuleFor(x=> x.Model.ProjectDescription).MaximumLength(300);
            RuleFor(x=> x.Model.Thumbnails).Must(list => list.Count <= 5).WithMessage("The maximum number of thumbnails is 5.");
        }
    }
}
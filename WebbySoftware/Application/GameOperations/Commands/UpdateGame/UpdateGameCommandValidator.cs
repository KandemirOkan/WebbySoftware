using FluentValidation;


namespace WebbySoftware.Application.GameOperations.Commands.UpdateGame{

    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>{

        public UpdateGameCommandValidator(){

            RuleFor(x => x.Model.ProjectName).MaximumLength(50);
            RuleFor(x=> x.Model.ProjectDescription).MaximumLength(300);
            RuleFor(x=> x.Model.Thumbnails).Must(list => list.Count <= 5).WithMessage("The maximum number of thumbnails is 5.");
        }
    }
}
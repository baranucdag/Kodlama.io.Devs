using FluentValidation;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValidator()
        {
            RuleFor(x => x.Name).NotEmpty();    
        }
    }
}

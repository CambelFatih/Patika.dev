using FluentValidation;

namespace WebApi.Application.AuthorOperation.Commands.UpdateAuthor
{
    /// <summary>
    /// Validator for UpdateAuthorCommand to define validation rules for updating author information.
    /// </summary>
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            // Define validation rules for the author's name and surname in the model.
            RuleFor(command => command.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(command => command.Model.Surname).MinimumLength(3).NotEmpty();
        }
    }
}

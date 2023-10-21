using FluentValidation;
using WebApi.Application.AuthorOperation.Commands.DeleteAuthor;

namespace WebApi.Application.AuthorOperation.Commands.CreateAuthor
{
    /// <summary>
    /// Validator for DeleteAuthorCommand to define validation rules for deleting an author by ID.
    /// </summary>
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}

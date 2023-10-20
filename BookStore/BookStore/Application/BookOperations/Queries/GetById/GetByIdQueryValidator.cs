using FluentValidation;
using Web.Application.Queries.BookOperations.GetById;

namespace WebApi.Application.Queries.BookOperations.GetById{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>{
        public GetByIdQueryValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
    }
}
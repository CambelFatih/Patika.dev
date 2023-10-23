using FluentValidation;
using Web.Application.Queries.BookOperations.GetBookDetail;

namespace WebApi.Application.Queries.BookOperations.GetById{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
    }
}
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.DbOperations;
using Web.Application.Queries.BookOperations.GetBookDetail;
namespace Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetBookDetailCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Theory]
        [InlineData(67)]
        [InlineData(68)]
        [InlineData(101)]
        [InlineData(78)]
        [InlineData(987654)]
        [InlineData(890)]
        public void WhenAuthorIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            var authorId = id;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId=id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found.");

        }
    }
}
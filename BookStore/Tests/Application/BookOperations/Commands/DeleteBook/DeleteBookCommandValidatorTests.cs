using BookStore.UnitTest.TestSetup;
using FluentAssertions;
using WebApi.Application.Commands.BookOperations.DeleteBook;

namespace BookStore.UnitTest.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-552)]
        public void WhenInvalidInputsAreGiven_Validator_ReturnErrors(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
using BookStore.UnitTest.TestSetup;
using FluentAssertions;
using WebApi.Application.AuthorOperation.Commands.UpdateAuthor;
namespace BookStore.UnitTest.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("aaaa", "")]
        [InlineData("", "aaaa")]
        [InlineData("a", "a")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorModel
            {
                Name = name,
                Surname = surname
            };
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
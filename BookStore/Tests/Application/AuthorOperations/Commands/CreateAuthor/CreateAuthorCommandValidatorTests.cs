using AutoMapper;
using BookStore.UnitTest.TestSetup;
using FluentAssertions;
using WebApi.Application.AuthorOperation.Commands.CreateAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace BookStore.UnitTest.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Serkan", " ")]
        [InlineData(" ", "Yilmaz")]
        [InlineData("Frank", "")]
        [InlineData(" ", " ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel
            {
                Name = name,
                Surname = surname
            };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
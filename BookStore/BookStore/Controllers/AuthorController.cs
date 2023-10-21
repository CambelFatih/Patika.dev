using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperation.Commands.CreateAuthor;
using WebApi.Application.AuthorOperation.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperation.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperation.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperation.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase{
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>API controller for managing authors.</summary>
        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>Get a list of authors.</summary>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            // Create a query to get authors
            GetAuthorsQuery query = new GetAuthorsQuery(_mapper, _context);
            var obj = query.Handle();
            return Ok(obj);
        }
        /// <summary>Get author by ID.</summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            query.AuthorId = id;
            var obj = query.Handle();
            return Ok(obj);


        }
        /// <summary>Create a new author.</summary>
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel model)
        {
            // Create a command to create an author
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;
            // Create a validator for the create author command and validate it
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle the create author command
            command.Handle();
            return Ok();

        }
        /// <summary>Update an author by ID.</summary>
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id , [FromBody] UpdateAuthorModel model)
        {
            // Create a command to update an author
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = model;
            command.AuthorId = id;
            // Create a validator for the update author command and validate it
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle the update author command
            command.Handle();
            return Ok();

        }
        /// <summary>Delete an author by ID.</summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // Create a command to delete an author
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            // Create a validator for the delete author command and validate it
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle the delete author command
            command.Handle();
            return Ok();

        }
    }
}
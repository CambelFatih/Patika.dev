using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Queries.BookOperations.GetById;
using WebApi.Application.Commands.BookOperations.CreateBook;
using WebApi.Application.Commands.BookOperations.DeleteBook;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.Application.Queries.BookOperations.GetById;
using WebApi.Application.Commands.BookOperations.UpdateBook;
using WebApi.DbOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private readonly IBookStoreDbContext _context;
        private readonly IMapper  _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                GetBooksQuery query = new GetBooksQuery(_context, _mapper);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                BookDetailModel result;
                GetByIdQuery query = new GetByIdQuery(_context, _mapper);
                GetByIdQueryValidator validator = new GetByIdQueryValidator();
                query.BookId = id;
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context, _mapper);

                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id ,[FromBody] UpdateBookModel updatedBook )
        {
            try
            {
                UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
                updateBookCommand.Model = updatedBook;
                updateBookCommand.BookId = id;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(updateBookCommand);
                updateBookCommand.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
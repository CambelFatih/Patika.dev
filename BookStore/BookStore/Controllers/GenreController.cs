
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperation.Command.CreateGenre;
using WebApi.Application.GenreOperation.Command.DeleteGenre;
using WebApi.Application.GenreOperation.Command.UpdateGenre;
using WebApi.Application.GenreOperation.Queries.GetGenres;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;
using WebApi.DbOperations;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_mapper,_context);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
                query.GenreId = id;
                GetGenreQueryDetailValidator validator = new GetGenreQueryDetailValidator();
                validator.ValidateAndThrow(query);
                var genre = query.Handle();
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            try
            {
                CreateGenreCommand command = new CreateGenreCommand(_context);
                command.Model = newGenre;
                CreateGenreCommandValidator validatior = new CreateGenreCommandValidator();
                validatior.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id , [FromBody] UpdateGenreModel updateGenre){
            try
            {
                UpdateGenreCommand command = new UpdateGenreCommand(_context);
                command.GenreId = id;
                command.Model = updateGenre;
                UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                DeleteGenreCommand command = new DeleteGenreCommand(_context);
                command.GenreId = id;
                DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
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
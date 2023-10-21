
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
    /// <summary>Controller for managing genre operations.</summary>
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>Constructor for GenreController.</summary>
        /// <param name="mapper">AutoMapper instance.</param>
        /// <param name="context">Database context.</param>
        public GenreController(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>Get a list of genres.</summary>
        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_mapper,_context);
            var obj = query.Handle();
            return Ok(obj);
        }
        /// <summary>Get a genre by its ID.</summary>
        /// <param name="id">The ID of the genre to retrieve.</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
            query.GenreId = id;
            GetGenreQueryDetailValidator validator = new GetGenreQueryDetailValidator();
            validator.ValidateAndThrow(query);
            var genre = query.Handle();
            return Ok(genre);

        }
        /// <summary>Add a new genre.</summary>
        /// <param name="newGenre">The model for creating a new genre.</param>
        [HttpPut]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;
            CreateGenreCommandValidator validatior = new CreateGenreCommandValidator();
            validatior.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
        /// <summary>Update a genre by its ID.</summary>
        /// <param name="id">The ID of the genre to update.</param>
        /// <param name="updateGenre">The model for updating the genre.</param>
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id , [FromBody] UpdateGenreModel updateGenre){

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
    

        }
        /// <summary>Delete a genre by its ID.</summary>
        /// <param name="id">The ID of the genre to delete.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {

            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
    }
}
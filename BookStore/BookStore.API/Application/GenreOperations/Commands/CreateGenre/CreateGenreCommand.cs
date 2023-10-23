using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperation.Command.CreateGenre
{
    /// <summary>
    /// CreateGenreCommand is the command used to create a new genre.
    /// </summary>
    public class CreateGenreCommand
    {
        /// <summary>
        /// The model containing the details of the new genre to be created.
        /// </summary>
        public CreateGenreModel Model { get; set; }

        private readonly IBookStoreDbContext _context;

        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the creation of a new genre.
        /// </summary>
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre is not null)
            {
                throw new InvalidOperationException("This genre already exists.");
            }

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Model representing the details of a new genre to be created.
    /// </summary>
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}

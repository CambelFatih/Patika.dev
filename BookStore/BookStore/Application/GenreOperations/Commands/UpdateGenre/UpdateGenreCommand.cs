using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperation.Command.UpdateGenre
{
    /// <summary>
    /// UpdateGenreCommand is the command used to update a genre.
    /// </summary>
    public class UpdateGenreCommand
    {
        /// <summary>
        /// The ID of the genre to be updated.
        /// </summary>
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _context;

        /// <summary>
        /// The model containing the details of the genre to be updated.
        /// </summary>
        public UpdateGenreModel Model { get; set; }

        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the update of a genre.
        /// </summary>
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Genre not found.");
            }

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("A genre with the same name already exists.");
            }

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Model representing the details of a genre to be updated.
    /// </summary>
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

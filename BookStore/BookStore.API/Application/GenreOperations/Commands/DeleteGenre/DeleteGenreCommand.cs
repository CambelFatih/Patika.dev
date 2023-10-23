using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperation.Command.DeleteGenre
{
    /// <summary>
    /// DeleteGenreCommand is the command used to delete a genre by its ID.
    /// </summary>
    public class DeleteGenreCommand
    {
        /// <summary>
        /// The ID of the genre to be deleted.
        /// </summary>
        public int GenreId { get; set; }

        private readonly IBookStoreDbContext _context;

        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the deletion of a genre by its ID.
        /// </summary>
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Genre not found.");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}

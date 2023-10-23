using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperation.Commands.DeleteAuthor
{
    /// <summary>
    /// DeleteAuthorCommand is the command used to delete an author by their ID.
    /// </summary>
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _context;

        /// <summary>
        /// The ID of the author to be deleted.
        /// </summary>
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the author deletion process.
        /// </summary>
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);

            if (AuthorId <= 0)
            {
                throw new InvalidOperationException("Invalid ID input provided");
            }

            if (author is null)
            {
                throw new InvalidOperationException("Invalid ID input provided");
            }

            var authorHasBooks = _context.Books.Any(x => x.AuthorId == AuthorId);

            if (authorHasBooks)
            {
                throw new InvalidProgramException("Invalid ID input provided");//The author has books in the database.
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}

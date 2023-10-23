using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.Commands.BookOperations.DeleteBook
{
    /// <summary>
    /// DeleteBookCommand is the command used to delete a book by its ID.
    /// </summary>
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _context;

        /// <summary>
        /// The ID of the book to be deleted.
        /// </summary>
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the book deletion process.
        /// </summary>
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
            {
                throw new InvalidOperationException("Book not found.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.Commands.BookOperations.UpdateBook
{
    /// <summary>
    /// UpdateBookCommand is the command used to update book information.
    /// </summary>
    public class UpdateBookCommand
    {
        /// <summary>
        /// The model containing the updated book information.
        /// </summary>
        public UpdateBookModel Model { get; set; }

        /// <summary>
        /// The ID of the book to be updated.
        /// </summary>
        public int BookId { get; set; }

        private readonly IBookStoreDbContext _context;

        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the book information update process.
        /// </summary>
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
            {
                throw new InvalidOperationException("Book not found.");
            }

            // Update the book's title and genre ID if provided in the model.
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// The model used to update book information.
    /// </summary>
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}

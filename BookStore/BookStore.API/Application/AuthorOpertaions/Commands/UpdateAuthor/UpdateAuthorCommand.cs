using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperation.Commands.UpdateAuthor
{
    /// <summary>
    /// UpdateAuthorCommand is the command used to update author information.
    /// </summary>
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;

        /// <summary>
        /// The model containing the updated author information.
        /// </summary>
        public UpdateAuthorModel Model { get; set; }

        /// <summary>
        /// The ID of the author to be updated.
        /// </summary>
        public int AuthorId { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the author information update process.
        /// </summary>
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Author not found.");
            }

            // Update the author's name and surname if provided in the model.
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// The model used to update author information.
    /// </summary>
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

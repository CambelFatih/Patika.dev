using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperation.Commands.CreateAuthor
{
    /// <summary>
    /// CreateAuthorCommand is the command used to create a new author.
    /// </summary>
    public class CreateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// The model used to create an author.
        /// </summary>
        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the author creation process.
        /// </summary>
        public void Handle()
        {
            // Checks for the existence of an author with the same name and surname.
            var author = _context.Authors.FirstOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);

            if (author is not null)
            {
                throw new InvalidOperationException("An author with the same name and surname already exists.");
            }

            // Maps the model to the Author entity and adds it to the database.
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// The model used to create a new author.
    /// </summary>
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}

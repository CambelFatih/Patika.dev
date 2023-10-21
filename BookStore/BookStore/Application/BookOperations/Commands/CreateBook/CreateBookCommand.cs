using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.BookOperations.CreateBook
{
    /// <summary>
    /// CreateBookCommand is the command used to create a new book.
    /// </summary>
    public class CreateBookCommand
    {
        /// <summary>
        /// The model used to create a new book.
        /// </summary>
        public CreateBookModel Model { get; set; }

        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;

        public CreateBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the book creation process.
        /// </summary>
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("The book already exists.");
            }

            book = _mapper.Map<Book>(Model);

            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// The model used to create a new book.
    /// </summary>
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

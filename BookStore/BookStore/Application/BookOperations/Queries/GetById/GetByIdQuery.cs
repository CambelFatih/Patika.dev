using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Common;
using WebApi.DbOperations;

namespace Web.Application.Queries.BookOperations.GetById
{
    /// <summary>
    /// GetByIdQuery is a query used to retrieve details of a book by its ID.
    /// </summary>
    public class GetByIdQuery
    {
        /// <summary>
        /// The model used to store book details.
        /// </summary>
        public BookDetailModel Model { get; set; }

        /// <summary>
        /// The ID of the book to retrieve.
        /// </summary>
        public int BookId { get; set; }

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the retrieval of book details by its ID.
        /// </summary>
        /// <returns>BookDetailModel containing book details.</returns>
        public BookDetailModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Book not found.");
            }

            BookDetailModel bm = _mapper.Map<BookDetailModel>(book);
            return bm;
        }
    }

    /// <summary>
    /// Model representing book details.
    /// </summary>
    public class BookDetailModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
    }
}

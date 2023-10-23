using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperation.Queries.GetAuthorDetail
{
    /// <summary>
    /// GetAuthorQuery is a query to retrieve detailed information about an author by their ID.
    /// </summary>
    public class GetAuthorQuery
    {
        /// <summary>
        /// The ID of the author to retrieve details for.
        /// </summary>
        public int AuthorId { get; set; }

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the retrieval of author details.
        /// </summary>
        /// <returns>AuthorDetailModel containing author details.</returns>
        public AuthorDetailModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Author not found.");
            }

            AuthorDetailModel returnObj = _mapper.Map<AuthorDetailModel>(author);
            return returnObj;
        }
    }

    /// <summary>
    /// Model representing detailed information about an author.
    /// </summary>
    public class AuthorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}

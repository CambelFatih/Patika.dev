using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperation.Queries.GetAuthors
{
    /// <summary>
    /// GetAuthorsQuery is a query to retrieve a list of authors.
    /// </summary>
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Handles the retrieval of a list of authors.
        /// </summary>
        /// <returns>List of GetAuthorModel containing author information.</returns>
        public List<GetAuthorModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.AuthorId);
            List<GetAuthorModel> authorModelList = _mapper.Map<List<GetAuthorModel>>(authors);
            return authorModelList;
        }
    }

    /// <summary>
    /// Model representing author information.
    /// </summary>
    public class GetAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}

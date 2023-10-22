using WebApi.DbOperations;
using WebApi.Entities;

namespace BookStore.UnitTest.TestSetup
{
    public static class Authors
    {
        public static void AddAuthor(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author { Name = "Frank", Surname = "Herbert" },
                new Author { Name = "Charlotte Perkins", Surname = "Gilman" }
            );
        }
    }
}
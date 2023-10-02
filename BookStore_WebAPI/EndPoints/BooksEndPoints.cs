using BookStore_WebAPI.Entities;

namespace BookStore_WebAPI.EndPoints
{
    public static class BooksEndPoints
    {

        const string GetBookEndPointName = "GetBook";

        static List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Designing Data-Intensive Applications",
                    Author = "Martin Kleppmann",
                    Price = 150,
                    publishedYear = 2016
                },
                new Book()
                {
                    Id = 2,
                    Title = "Fundamentals of Data Engineering",
                    Author = "Joe Reis",
                    Price = 100,
                    publishedYear = 2022
                }
            };
        public static RouteGroupBuilder MapBooksEndPoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/books")
                              .WithParameterValidation();


            //app.MapGet("/", () => "Hello World!");

            // Get all books
            group.MapGet("/", () => books);

            // Get a book by Id
            group.MapGet("/{id}", (int id) =>
            {
                Book book = books.Find((book) => book.Id == id);
                if (book is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(book);
            }

            ).WithName(GetBookEndPointName);

            // Post a book
            group.MapPost("/", (Book book) =>
            {
                book.Id = books.Max(book => book.Id) + 1;
                books.Add(book);

                return Results.CreatedAtRoute(GetBookEndPointName, new { id = book.Id }, book);
            }

            );

            // Put/Update a book
            group.MapPut("/{id}", (int id, Book updatedBook) =>
            {
                Book existingBook = books.Find((book) => book.Id == id);

                if (existingBook is null)
                {
                    return Results.NotFound();
                }

                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.publishedYear = updatedBook.publishedYear;
                existingBook.Price = updatedBook.Price;

                return Results.NotFound();
            }
            );

            // Delete a book
            group.MapDelete("/{id}", (int id) =>
            {
                Book book = books.Find(book => book.Id == id);

                if (book is not null)
                {
                    books.Remove(book);
                }

                return Results.NoContent();

            });
            return group;
        }
    }
}

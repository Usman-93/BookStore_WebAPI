using BookStore_WebAPI.Entities;
using BookStore_WebAPI.Respositories;

namespace BookStore_WebAPI.EndPoints
{
    public static class BooksEndPoints
    {
        const string GetBookEndPointName = "GetBook";

        public static RouteGroupBuilder MapBooksEndPoints(this IEndpointRouteBuilder routes)
        {
            //InMemBooksRepository booksRepository = new InMemBooksRepository();

            var group = routes.MapGroup("/books")
                              .WithParameterValidation();


            //app.MapGet("/", () => "Hello World!");

            // Get all books
            group.MapGet("/", (IBooksRepository booksRepository) => booksRepository.GetAll());

            // Get a book by Id
            group.MapGet("/{id}", (IBooksRepository booksRepository, int id) =>
            {
                Book book = booksRepository.Get(id);
                if (book is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(book);
            }

            ).WithName(GetBookEndPointName);

            // Post a book
            group.MapPost("/", (IBooksRepository booksRepository, Book book) =>
            {
                booksRepository.Create(book);

                return Results.CreatedAtRoute(GetBookEndPointName, new { id = book.Id }, book);
            }

            );

            // Put/Update a book
            group.MapPut("/{id}", (IBooksRepository booksRepository, int id, Book updatedBook) =>
            {
                Book existingBook = booksRepository.Get(id);

                if (existingBook is null)
                {
                    return Results.NotFound();
                }

                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.publishedYear = updatedBook.publishedYear;
                existingBook.Price = updatedBook.Price;

                booksRepository.Update(existingBook);

                return Results.NotFound();
            }
            );

            // Delete a book
            group.MapDelete("/{id}", (IBooksRepository booksRepository, int id) =>
            {
                Book book = booksRepository.Get(id);

                if (book is not null)
                {
                    booksRepository.Delete(book.Id);
                }

                return Results.NoContent();

            });
            return group;
        }
    }
}

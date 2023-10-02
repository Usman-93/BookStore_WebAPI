using BookStore_WebAPI.Entities;

namespace BookStore_WebAPI.Respositories
{
    public class InMemBooksRepository
    {

        private List<Book> books = new List<Book>()
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

        // return all books
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        // return a book using an Id
        public Book? Get(int id)
        {
            return books.Find(x => x.Id == id);
        }

        // Create a book
        public void Create(Book book)
        {
            book.Id = books.Max(book => book.Id) + 1;
            books.Add(book);
        }

        // Update a book
        public void Update(Book updatedBook)
        {
            int index = books.FindIndex(x => x.Id == updatedBook.Id);
            books[index] = updatedBook;
        }

        // Delete a book
        public void Delete(int id) 
        {
            Book book = books.Find(book => book.Id == id);
            books.Remove(book);
        }

    }
}

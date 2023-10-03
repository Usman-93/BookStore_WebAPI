using BookStore_WebAPI.Entities;

namespace BookStore_WebAPI.Respositories
{
    public interface IBooksRepository
    {
        void Create(Book book);
        void Delete(int id);
        Book? Get(int id);
        IEnumerable<Book> GetAll();
        void Update(Book updatedBook);
    }
}
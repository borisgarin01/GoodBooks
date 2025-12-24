using Models;

namespace GoodBooks.Services;

public interface IBooksService
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book> GetAsync(int bookId);
    public Task AddAsync(Book book);
    public Task DeleteAsync(int bookId);
}
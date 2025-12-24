using GoodBooks.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace GoodBooks.Services;

public sealed class BooksService : IBooksService
{
    private readonly GoodBooksDbContext _goodBooksDbContext;

    public BooksService(GoodBooksDbContext goodBooksDbContext)
    {
        _goodBooksDbContext = goodBooksDbContext;
    }

    public async Task AddAsync(Book book)
    {
        _goodBooksDbContext.Books.Add(book);
        await _goodBooksDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int bookId)
    {
        Book? book = await GetAsync(bookId);
        if (book is not null)
        {
            _goodBooksDbContext.Books.Remove(book);
            await _goodBooksDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _goodBooksDbContext.Books.ToListAsync();
    }

    public async Task<Book> GetAsync(int bookId)
    {
        return await _goodBooksDbContext.Books.FindAsync(bookId);
    }
}

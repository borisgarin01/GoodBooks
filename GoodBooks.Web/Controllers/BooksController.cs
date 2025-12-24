using GoodBooks.Services;
using GoodBooks.Web.RequestsModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace GoodBooks.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBooksService _booksService;

    public BooksController(ILogger<BooksController> logger, IBooksService booksService)
    {
        _logger = logger;
        _booksService = booksService;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<ActionResult<IEnumerable<Book>>> Get()
    {
        IEnumerable<Book> books = await _booksService.GetAllAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<ActionResult> Post(AddBookModel addBookModel)
    {
        var book = new Book
        {
            Author = addBookModel.Author,
            CreatedOn = addBookModel.CreatedOn,
            UpdatedOn = addBookModel.UpdatedOn,
            Title = addBookModel.Title
        };
        await _booksService.AddAsync(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        Book? book = await _booksService.GetAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpDelete("{id}", Name = "DeleteBookById")]
    public async Task<ActionResult<Book>> Delete(int id)
    {
        Book? book = await _booksService.GetAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        await _booksService.DeleteAsync(id);
        return NoContent();
    }
}

namespace GoodBooks.Web.RequestsModels;

public sealed record AddBookModel
{
    public DateTime CreatedOn { get; init; }
    public DateTime UpdatedOn { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
}

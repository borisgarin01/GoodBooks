namespace Models;

public record Book
{
    public int Id { get; init; }
    public DateTime CreatedOn { get; init; }
    public DateTime UpdatedOn { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
}
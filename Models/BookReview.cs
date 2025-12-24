namespace Models;

public record BookReview
{
    public int Id { get; init; }
    DateTime CreatedOn { get; init; }
    DateTime UpdatedOn { get; init; }
    string ReviewAuthor { get; init; }
    string ReviewContent { get; init; }

    public virtual Book Book { get; init; }
}
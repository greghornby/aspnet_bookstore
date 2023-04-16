using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("books")]
public class BooksModel
{
    public required long id { get; set; }
    public required string title { get; set; }
    public required string isbn { get; set; }

    public required long authorID { get; set; }
    public AuthorsModel? author { get; set; }

    public ICollection<BookReviewsModel>? reviews { get; set; }
}
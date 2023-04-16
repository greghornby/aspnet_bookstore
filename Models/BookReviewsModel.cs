using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("book_reviews")]
public class BookReviewsModel
{
    public required long id { get; set; }
    public required string content { get; set; }
    public required int rating { get; set; }

    public required long bookID { get; set; }
    public BooksModel? book  { get; set; }
}
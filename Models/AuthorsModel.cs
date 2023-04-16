using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("authors")]
public class AuthorsModel
{
    public required long id { get; set; }
    public required string fullName { get; set; }

    public ICollection<BooksModel>? books { get; set; }
}
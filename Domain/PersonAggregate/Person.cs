using Domain.BookAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.PersonAggregate
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public List<Book>? Books { get; set; }
        [NotMapped]
        public string? FullName { get { return FirstName + " " + LastName; } }
    }
}

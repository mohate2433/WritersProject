using Domain.PersonAggregate;

namespace Domain.BookAggregate
{
    public class Book
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public int UnitPrice { get; set; }
        public int NumberOfPage { get; set; }
        public string? Description { get; set; }
        public string? BookFile { get; set; }
        public Person? Person { get; set; }
    }
}

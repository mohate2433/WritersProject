namespace ApplicationService.Dtos
{
    public class BookDto
    {   
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public int UnitPrice { get; set; }
        public int NumberOfPage { get; set; }
        public string? Description { get; set; }
        public string? BookFile { get; set; }
        public string? FullName { get; set; }
        public List<PersonDto> People { get; set; }
        public PersonDto? Person { get; set; }
    }
}

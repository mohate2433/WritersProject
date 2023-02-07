namespace ApplicationService.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? FullName { get { return FirstName + " " + LastName; } }
        public List<BookDto>? Books { get; set; }
        //private string? FullName1;

        //public string? FullName
        //{
        //    get { return FullName1; }
        //    set { FullName1 = FirstName + " " + LastName; }
        //}

    }
}

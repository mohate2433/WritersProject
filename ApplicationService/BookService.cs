using ApplicationService.Contract;
using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using Domain.BookAggregate;
using Domain.PersonAggregate;
using EfCore.Contract;

namespace ApplicationService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPersonRepository _personRepository;

        public BookService(IBookRepository bookRepository, IPersonRepository personRepository)
        {
            _bookRepository = bookRepository;
            _personRepository = personRepository;
        }

        
        private static List<SelectBookDto> Convert(List<Book> books)
        {
            var dtoList = new List<SelectBookDto>();

                var person = new List<SelectPersonDto>();
            for (int i = 0; i < books.Count; i++)
            {
                dtoList.Add(new SelectBookDto());
                dtoList[i].Id = books[i].Id;
                dtoList[i].BookFile = books[i].BookFile;
                dtoList[i].Description = books[i].Description;
                dtoList[i].Name = books[i].Name;
                dtoList[i].UnitPrice = books[i].UnitPrice;
                dtoList[i].PersonId = books[i].PersonId;
                dtoList[i].NumberOfPage = books[i].NumberOfPage;
                dtoList[i].FullName = books[i].Person.FullName;
                
            }
            return dtoList;
        }

        private static Book Convert(CreateBookDto create)
        {
            var book = new Book()
            { 
                Name = create.Name,
                Description = create.Description,
                PersonId = create.PersonId,
                UnitPrice = create.UnitPrice,
                BookFile = create.BookFile,
                NumberOfPage = create.NumberOfPage
            };
            return book;
        }

        private static Book Convert(EditBookDto edit)
        {
            var book = new Book()
            {
                Id = edit.Id,
                Name = edit.Name,
                Description = edit.Description,
                PersonId = edit.PersonId,
                UnitPrice = edit.UnitPrice,
                BookFile = edit.BookFile,
                NumberOfPage = edit.NumberOfPage
            };
            return book;
        }

        private static DetailBookDto Convert(Book book)
        {
            var detailDto = new DetailBookDto()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                PersonId = book.PersonId,
                UnitPrice = book.UnitPrice,
                BookFile = book.BookFile,
                NumberOfPage = book.NumberOfPage,

                
            };
            return detailDto;
        }

        private static EditBookDto ConvertEdit(Book book)
        {
            var editDto = new EditBookDto()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                PersonId = book.PersonId,
                UnitPrice = book.UnitPrice,
                BookFile = book.BookFile,
                NumberOfPage = book.NumberOfPage
            };
            return editDto;
        }
        public void Create(CreateBookDto create) => _bookRepository.Create(Convert(create));

        public void Delete(int id) => _bookRepository.Delete(id);

        public void Edit(EditBookDto edit) => _bookRepository.Update(Convert(edit));

        public DetailBookDto Find(int id) => Convert(_bookRepository.Get(id));

        public EditBookDto FindEdit(int id) =>  ConvertEdit(_bookRepository.Get(id));

        public List<SelectBookDto> Select() => BookService.Convert(_bookRepository.SelectAll());


    }
}

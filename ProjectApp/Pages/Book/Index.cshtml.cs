using ApplicationService.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService, IPersonService personService)
        {
            _bookService = bookService;
        }

        public IList<SelectBookDto> Book { get; set; } = default!;

        public IActionResult OnGet()
        {
            
            Book = _bookService.Select();
            return Page();
        }
    }
}

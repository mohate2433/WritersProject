using ApplicationService.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public DetailsModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public DetailBookDto Book { get; set; } = default!;

        public IActionResult OnGetAsync(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var book = _bookService.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}

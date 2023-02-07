using ApplicationService.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Book
{
    public class DeleteModel : PageModel
    {
        private readonly IBookService _bookService;

        public DeleteModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public EditBookDto Book { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.FindEdit(id);

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

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
                _bookService.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}

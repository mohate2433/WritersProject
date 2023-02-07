using ApplicationService.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectApp.Pages.Book
{
    public class EditModel : PageModel
    {

        private readonly IBookService _bookService;
        private readonly IPersonService _personService;

        public EditModel(IBookService bookService, IPersonService personService)
        {
            _bookService = bookService;
            _personService = personService;
        }

        [BindProperty]
        public EditBookDto Book { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _bookService.FindEdit(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_personService.Select(), "Id", "FullName");
            Book = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }            
            _bookService.Edit(Book);

            return RedirectToPage("./Index");
        }
    }
}

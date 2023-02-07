using ApplicationService.Contract;
using ApplicationService.Dtos;
using ApplicationService.Dtos.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectApp.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IPersonService _personService;

        public CreateModel(IBookService bookService, IPersonService personService)
        {
            _bookService = bookService;
            _personService = personService;
        }

        public IActionResult OnGet()
        {
            var book = _bookService.Select();
            ViewData["PersonId"] = new SelectList(_personService.Select(), "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public CreateBookDto Book { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookService.Create(Book);

            return RedirectToPage("./Index");
        }
    }
}

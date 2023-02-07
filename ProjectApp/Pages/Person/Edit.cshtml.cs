using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly IPersonService _personService;

        public EditModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public EditPersonDto Person { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personService.FindEdit(id);
            if (person == null)
            {
                return NotFound();
            }
            Person = person;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _personService.Edit(Person);

            return RedirectToPage("./Index");
        }
    }
}

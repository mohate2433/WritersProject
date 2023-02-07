using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Pages.Person
{
    public class DeleteModel : PageModel
    {
        private readonly IPersonService _personService;

        public DeleteModel(IPersonService personService)
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
            else
            {
                Person = person;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

                _personService.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}

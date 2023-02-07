using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly IPersonService _personService;

        public CreateModel(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreatePersonDto Person { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _personService.Create(Person);

            return RedirectToPage("./Index");
        }
    }
}

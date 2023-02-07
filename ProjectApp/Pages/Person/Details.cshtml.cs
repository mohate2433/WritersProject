using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly IPersonService _personService;

        public DetailsModel(IPersonService personService)
        {
            _personService = personService;
        }

        public DetailPersonDto Person { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personService.Find(id);
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
    }
}

using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectApp.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public IList<SelectPersonDto> Person { get; set; } = default!;

        public IActionResult OnGet()
        {
            Person = _personService.Select();
            return Page();
        }
    }
}

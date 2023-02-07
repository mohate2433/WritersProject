using ApplicationService.Contract;
using ApplicationService.Dtos.PersonDtos;
using Domain.PersonAggregate;
using EfCore.Contract;

namespace ApplicationService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        private static List<SelectPersonDto> Convert(List<Person> person)
        {
            var dtoList = new List<SelectPersonDto>();
            for (int i = 0; i < person.Count; i++)
            {
                dtoList.Add(new SelectPersonDto());
                dtoList[i].Id = person[i].Id;
                dtoList[i].FirstName = person[i].FirstName;
                dtoList[i].LastName = person[i].LastName;
                dtoList[i].Bio = person[i].Bio;
            }
            return dtoList;
        }

        private static Person Convert(CreatePersonDto create)
        {
            var person = new Person()
            {
                FirstName = create.FirstName,
                LastName = create.LastName,
                Bio = create.Bio
            };
            return person;
        }

        private static Person Convert(EditPersonDto edit)
        {
            var person = new Person()
            {
                Id = edit.Id,
                FirstName = edit.FirstName,
                LastName = edit.LastName,
                Bio = edit.Bio
            };
            return person;
        }

        private static DetailPersonDto Convert(Person person)
        {
            var detailDto = new DetailPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Bio = person.Bio
            };
            return detailDto;
        }

        private static EditPersonDto ConvertEdit(Person person)
        {
            var editDto = new EditPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Bio = person.Bio
            };
            return editDto;
        }
        public void Create(CreatePersonDto create) => _personRepository.Create(Convert(create));

        public void Delete(int id) => _personRepository.Delete(id);

        public void Edit(EditPersonDto edit) => _personRepository.Update(Convert(edit));

        public DetailPersonDto Find(int id) => Convert(_personRepository.Get(id));

        public EditPersonDto FindEdit(int id) => ConvertEdit(_personRepository.Get(id));

        public List<SelectPersonDto> Select() => PersonService.Convert(_personRepository.GetAll());
    }
}

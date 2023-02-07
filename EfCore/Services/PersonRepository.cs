using Domain.PersonAggregate;
using EfCore.Contract;
using EntityFramework.GenericEfCore.Service;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class PersonRepository : Repository<int, Person>, IPersonRepository
    {
        private readonly ProjectDbContext _context;
        public PersonRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

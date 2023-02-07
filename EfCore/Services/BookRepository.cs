using Domain.BookAggregate;
using EfCore.Contract;
using EntityFramework.GenericEfCore.Service;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class BookRepository : Repository<int , Book> , IBookRepository
    {
        private readonly ProjectDbContext _context;

        public BookRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Book> SelectAll()
        {
            return _context.Book.Include(x=>x.Person).ToList();
        }
    }
}

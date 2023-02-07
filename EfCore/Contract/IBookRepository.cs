using Domain.BookAggregate;
using EntityFramework.GenericEfCore.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Contract
{
    public interface IBookRepository : IRepository< int , Book>
    {
        public List<Book> SelectAll();
    }
}

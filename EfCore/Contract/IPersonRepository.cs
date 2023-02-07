using Domain.PersonAggregate;
using EntityFramework.GenericEfCore.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Contract
{
    public interface IPersonRepository : IRepository<int , Person>
    {

    }
}

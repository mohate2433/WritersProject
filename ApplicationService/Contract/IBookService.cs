using ApplicationService.Dtos.BookDtos;
using Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contract
{
    public interface IBookService
    {
        List<SelectBookDto> Select();
        void Create(CreateBookDto create);
        DetailBookDto Find(int id);
        EditBookDto FindEdit(int id);
        void Edit(EditBookDto edit);
        void Delete(int id);
    }
}

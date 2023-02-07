using ApplicationService.Dtos.BookDtos;
using ApplicationService.Dtos.PersonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contract
{
    public interface IPersonService
    {
        List<SelectPersonDto> Select();
        void Create(CreatePersonDto create);
        DetailPersonDto Find(int id);
        EditPersonDto FindEdit(int id);
        void Edit(EditPersonDto edit);
        void Delete(int id);
    }
}

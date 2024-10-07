using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICarService
    {
        void Delete(int id);
        void Create(CreateCarDto model);
        void Edit(EditCarDto model);
        CarDto? Get(int id);
        IEnumerable<CarDto> GetAll();
    }
}

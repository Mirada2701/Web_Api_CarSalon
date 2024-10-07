using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarService : ICarService
    {
        private readonly CarSalonDbContext ctx;
        private readonly IMapper mapper;

        public CarService(CarSalonDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public void Create(CreateCarDto model)
        {
            ctx.Cars.Add(mapper.Map<Car>(model));
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return;

            ctx.Cars.Remove(car);
            ctx.SaveChanges();
        }

        public void Edit(EditCarDto model)
        {

            ctx.Cars.Update(mapper.Map<Car>(model));
            ctx.SaveChanges();
        }

        public CarDto? Get(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return null;
            //load car category
            ctx.Entry(car).Reference(x => x.Category).Load();

            return mapper.Map<CarDto>(car);
        }

        public IEnumerable<CarDto> GetAll()
        {
            return mapper.Map<List<CarDto>>(ctx.Cars.ToList());
        }
    }
}

using AutoMapper;
using Core.Dtos;
using Core.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_CarSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarSalonDbContext ctx;
        private readonly IMapper mapper;

        public CarsController(CarSalonDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var cars = mapper.Map<List<CarDto>>(ctx.Cars.ToList());
            return Ok(cars);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var car = ctx.Cars.Find(id);

            if(car == null) return NotFound();
            //load car category
            ctx.Entry(car).Reference(x => x.Category).Load();



            return Ok(mapper.Map<CarDto>(car));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var car = ctx.Cars.Find(id);

            if (car == null) return NotFound();

           

            ctx.Cars.Remove(car);
            ctx.SaveChanges();

            return Ok();
        }
        [HttpPost]
        public IActionResult Create(CreateCarModel model)
        {
            if(!ModelState.IsValid) return BadRequest();   


            ctx.Cars.Add(mapper.Map<Car>(model));
            ctx.SaveChanges();

            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(Car model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Cars.Update(model);
            ctx.SaveChanges();

            return Ok();
        }
    }
}

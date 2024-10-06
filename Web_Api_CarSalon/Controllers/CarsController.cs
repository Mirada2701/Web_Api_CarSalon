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

        public CarsController(CarSalonDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Cars.ToList());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var car = ctx.Cars.Find(id);

            if(car == null) return NotFound();
            return Ok(car);
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
        public IActionResult Create(Car model)
        {
            if(!ModelState.IsValid) return BadRequest();   

            ctx.Cars.Add(model);
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

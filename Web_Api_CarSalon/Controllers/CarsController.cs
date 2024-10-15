using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_CarSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(carService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok(carService.Get(id));
        }
        
        [HttpPost]
        public IActionResult Create(CreateCarDto model)
        {
            carService.Create(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(EditCarDto model)
        {
           carService.Edit(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            carService.Delete(id);
            return Ok();
        }
    }
}

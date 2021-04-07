using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _service;

        public CarsController(CarsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> getAllCars()
        {
            try
            {
                return Ok(_service.GetAllCars());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car newCar)
        {
            try
            {
                return Ok(_service.CreateCar(newCar));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            try
            {
                return Ok(_service.GetCarById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar([FromBody] Car editedCar, int id)
        {
            try
            {
                editedCar.Id = id;
                return Ok(_service.EditCar(editedCar));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(int id)
        {
            try
            {
                return Ok(_service.DeleteCar(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
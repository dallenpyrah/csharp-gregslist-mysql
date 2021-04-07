using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _service;

        public HousesController(HousesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<House>> GetAllHouses()
        {
            try
            {
                return Ok(_service.GetAllHouses());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<House> CreateHouse([FromBody] House newHouse)
        {
            try
            {
                return Ok(_service.CreateHouse(newHouse));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<House> GetHouseById(int id)
        {
            try
            {
                return (_service.GetHouseById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<House> EditHouse(int id, [FromBody] House editedHouse)
        {
            try
            {
                return (_service.EditHouse(id, editedHouse));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<House> DeleteHouse(int id)
        {
            try
            {
                return Ok(_service.DeleteHouse(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);                
            }
        }

    }
}
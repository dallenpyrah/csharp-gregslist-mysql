using System.Collections.Generic;
using gregslist_sql.Models;
using gregslist_sql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_sql.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;

        public JobsController(JobsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAllJobs()
        {
            try
            {
                return Ok(_service.GetAllJobs());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(int id)
        {
            try
            {
                return Ok(_service.GetJobById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Job> CreateJob([FromBody] Job newJob)
        {
            try
            {
                return Ok(_service.CreateJob(newJob));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Job> EditJob(int id, [FromBody] Job editedJob)
        {
            try
            {
                editedJob.Id = id;
                return Ok(_service.EditJob(editedJob));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> DeleteJob(int id)
        {
            try
            {
                return Ok(_service.DeleteJob(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWatch.Models;
using VehicleWatch.Services;

namespace VehicleWatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReport _repo;
        public ReportController(IReport repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Report>> GetAll()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to retrive data from database");
            }
        }
        // 
        [HttpGet("{vehicleId}")]
        public async Task<ActionResult<Report>> GetAllHistory(int vehicleId)
        {
            try
            {
                var vehicle = await _repo.GetAllHistoryById(vehicleId);
                if (vehicle == null)
                {
                    return NotFound($"Report with {vehicleId} was not found.");
                }
                return Ok(vehicle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error to retrive data from database");
            }
        }

        [HttpGet("reportId")]
        public async Task<ActionResult<Report>> GetSingel(int reportId)
        {
            try
            {
                var vehicle = await _repo.GetSingel(reportId);
                if (vehicle == null)
                {
                    return NotFound($"Report with {reportId} was not found.");
                }
                return Ok(vehicle);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to retrive data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Report>> AddNewReport(Report newReport)
        {
            try
            {
                if (newReport == null)
                {
                    return BadRequest();
                }
                var result = await _repo.Add(newReport);
                return CreatedAtAction(nameof(GetSingel),
                    new { id = result.ReportId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to create data in the Database.");
            }

        }
        /*
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Report>> DeletReport(int id)
        {
            try
            {
                var reportToDelete = await _repo.GetSingel(id);
                if(reportToDelete == null)
                {
                    return NotFound($"Report with ID {id} was not found.");
                }
                return await _repo.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error to delete data from Database.");
            }
        }
        */


    }

}

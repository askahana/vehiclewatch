using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWatch.Services;

namespace VehicleWatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicle _repo;
        public VehicleController(IVehicle repo)
        {
            _repo = repo;
        }

        [HttpGet("{regnum}")]
        public async Task<ActionResult<int>> GetVehicleId(string regnum)
        {
            try
            {
                if (!await _repo.VehicleExists(regnum))
                {
                    return NotFound("Fordnet är inte registrerat.");
                }
                var vehicleId = await _repo.GetVehicleId(regnum);
                if (vehicleId == 0)
                {
                    return NotFound("VehicleId hittades inte.");
                }
                return Ok(vehicleId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error to retrive data from database");
            }
        }
    }
}

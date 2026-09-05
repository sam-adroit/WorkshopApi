using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Models;
using WorkshopApi.Interfaces;

namespace WorkshopApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class RegistrationController(IRegistrationService registrationService,
        IRegistrationRepository registrationRepository) : ControllerBase
    {
        [HttpPost("workshops/{workshopId:int}/register/{studentId:int}")]
        public async Task<ActionResult<Registration>> Register(int workshopId, int studentId, Registration registration)
        {
            registration.WorkshopId = workshopId;
            registration.StudentId = studentId;
            try
            {
                return Ok(await registrationService.Register(registration));
            }
            catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
            catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpGet("students/{studentId:int}/workshops")]
        public async Task<ActionResult<List<Workshop>>> GetStudentWorkshops(int studentId) =>
            Ok(await registrationRepository.GetStudentWorkshopsAsync(studentId));
    }
}

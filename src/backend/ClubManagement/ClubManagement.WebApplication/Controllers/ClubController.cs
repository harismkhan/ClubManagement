using ClubManagement.Services.Interfaces;
using ClubManagement.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ILogger<ClubController> logger;
        private readonly IClubService clubService;

        public ClubController(ILogger<ClubController> logger, IClubService clubService)
        {
            this.logger = logger;
            this.clubService = clubService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            ClubViewModel result;

            try
            {
                result = await clubService.GetById(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
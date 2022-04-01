using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> logger;
        private readonly ITeamService teamService;

        public TeamController(ILogger<TeamController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
        }

        [HttpPost]
        public async Task Create([FromBody] TeamCreateModel clubCreate)
        {

            try
            {
                await teamService.Create(clubCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                BadRequest();
            }
            Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(TeamUpdateModel clubUpdate, Guid id)
        {
            try
            {
                await teamService.Update(clubUpdate);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            TeamViewModel result;

            try
            {
                result = await teamService.GetById(id);
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<TeamViewModel> result;

            try
            {
                result = await teamService.GetAll();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult?> Delete(Guid id)
        {

            try
            {
                await teamService.Delete(id);
            }

            catch (ArgumentException ex)
            {
                logger.LogError(ex.Message);
                return NotFound();
            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }

            return Ok();
        }

    }
}
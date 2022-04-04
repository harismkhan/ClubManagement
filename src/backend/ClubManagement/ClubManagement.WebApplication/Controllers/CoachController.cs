using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ILogger<CoachController> logger;
        private readonly ICoachService coachService;

        public CoachController(ILogger<CoachController> logger, ICoachService coachService)
        {
            this.logger = logger;
            this.coachService = coachService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CoachCreateModel coachCreate)
        {

            try
            {
                await coachService.Create(coachCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CoachUpdateModel coachUpdate, Guid id)
        {
            try
            {
                await coachService.Update(coachUpdate);
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
            CoachViewModel result;

            try
            {
                result = await coachService.GetById(id);
            }
            catch (ArgumentException ex)
            {
                logger.LogInformation(ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<CoachViewModel> result;

            try
            {
                result = await coachService.GetAll();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult> GetAllByTeamId(Guid teamId)
        {
            IEnumerable<CoachViewModel> result;

            try
            {
                result = await coachService.GetAllByTeamId(teamId);
            }
            catch (ArgumentException ex)
            {
                logger.LogInformation(ex.Message);
                return NotFound();
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
                await coachService.Delete(id);
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

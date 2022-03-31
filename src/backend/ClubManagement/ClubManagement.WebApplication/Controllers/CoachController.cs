using ClubManagement.Domain.Models;
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
        public async Task Create([FromBody] CoachCreateModel coachCreate)
        {

            try
            {
                await coachService.Create(coachCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                BadRequest();
            }
            Ok();
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

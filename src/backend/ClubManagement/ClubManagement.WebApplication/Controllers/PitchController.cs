using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PitchController : ControllerBase
    {
        private readonly ILogger<PitchController> logger;
        private readonly IPitchService pitchService;

        public PitchController(ILogger<PitchController> logger, IPitchService pitchService)
        {
            this.logger = logger;
            this.pitchService = pitchService;
        }

        [HttpPost]
        public async Task Create([FromBody] PitchCreateModel pitchCreate)
        {

            try
            {
                await pitchService.Create(pitchCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                BadRequest();
            }
            Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(PitchUpdateModel pitchUpdate, Guid id)
        {
            try
            {
                await pitchService.Update(pitchUpdate);
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
            PitchViewModel result;

            try
            {
                result = await pitchService.GetById(id);
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
            IEnumerable<PitchViewModel> result;

            try
            {
                result = await pitchService.GetAll();
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
                await pitchService.Delete(id);
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
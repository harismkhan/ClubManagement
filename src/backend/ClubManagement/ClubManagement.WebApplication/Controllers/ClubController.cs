using ClubManagement.Domain.Models;
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<ClubViewModel> result;

            try
            {
                result = await clubService.GetAll();
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
                await clubService.Delete(id);
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

        [HttpPost]
        public void Create([FromBody]ClubCreateModel clubCreate)
        {
            ClubViewModel result;
             
            try
            {
                clubService.Create(clubCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                //return BadRequest();
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update(ClubUpdateModel clubUpdate, Guid id)
        {
            try
            {
                await clubService.Update(clubUpdate);
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
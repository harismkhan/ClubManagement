using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> logger;
        private readonly IPlayerService playerService;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        {
            this.logger = logger;
            this.playerService = playerService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PlayerCreateModel playerCreate)
        {

            try
            {
                await playerService.Create(playerCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(PlayerUpdateModel playerUpdate)
        {
            try
            {
                await playerService.Update(playerUpdate);
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

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            PlayerViewModel result;

            try
            {
                result = await playerService.GetById(id);
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
            IEnumerable<PlayerViewModel> result;

            try
            {
                result = await playerService.GetAll();
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
            IEnumerable<PlayerViewModel> result;

            try
            {
                result = await playerService.GetAllByTeamId(teamId);
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
                await playerService.Delete(id);
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

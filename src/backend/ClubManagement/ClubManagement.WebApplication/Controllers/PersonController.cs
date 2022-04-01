using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagement.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IPersonService personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            this.logger = logger;
            this.personService = personService;
        }

        [HttpPost]
        public async Task Create([FromBody] PersonCreateModel personCreate)
        {

            try
            {
                await personService.Create(personCreate);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                BadRequest();
            }
            Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(PersonUpdateModel personUpdate, Guid id)
        {
            try
            {
                await personService.Update(personUpdate);
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
            PersonViewModel result;

            try
            {
                result = await personService.GetById(id);
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
            IEnumerable<PersonViewModel> result;

            try
            {
                result = await personService.GetAll();
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
                await personService.Delete(id);
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

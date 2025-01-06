using Microsoft.AspNetCore.Mvc;
using MiddlewareApp.DTO;
using MiddlewareApp.Model.Entity;
using MiddlewareApp.Service;
using System.Runtime.InteropServices.JavaScript;


namespace MiddlewareApp.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class AdventurersController : Controller 
    {

        private readonly IAdventurersService _adventurersService;

        public AdventurersController(IAdventurersService adventurersService)
        {
            _adventurersService = adventurersService;
        }

        [HttpGet]
        public IActionResult GetAdventurers()
        {
            List<Adventurer> returnAdventurers = _adventurersService.GetAllAdventurers();

            if (returnAdventurers.Count == 0)
            {
                return NotFound("No adventurers found");
            }

            return Ok(returnAdventurers);
        }

        [HttpPost]
        public IActionResult AddAdventurer([FromBody] AdventurerDTO adventurerDTO)
        {
            AdventurerDTOWrapper userInputParse = new AdventurerDTOWrapper(adventurerDTO);
            if (!userInputParse.Success)
            {
                return BadRequest(userInputParse.Message);
            }
            _adventurersService.AddAdventurer(userInputParse.Result); 
            return Created("/adventurers", $"{userInputParse.Result.Name} has been added");
            
        }



    }
}

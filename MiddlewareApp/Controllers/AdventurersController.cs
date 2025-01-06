using Microsoft.AspNetCore.Mvc;
using MiddlewareApp.Model.Entity;
using MiddlewareApp.Service;


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
        public IActionResult AddAdventurer([FromBody] Adventurer userAdventurer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("This is a bad result");
            }

            _adventurersService.AddAdventurer(userAdventurer);
            return Created("/adventurers", $"{userAdventurer.Name} has been added");
        }



    }
}

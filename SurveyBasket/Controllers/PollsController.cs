namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController : ControllerBase
{

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        return Ok();
    }
}

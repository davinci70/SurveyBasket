namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_pollService.GetAll());
    }
    
    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        var poll = _pollService.Get(Id);
        return poll is null ? NotFound() : Ok(poll);
    }

    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
        var newPoll = _pollService.Add(request);

        return CreatedAtAction(nameof(GetById), new { Id = newPoll.Id }, newPoll);
    }

    [HttpPut("{Id}")]
    public IActionResult Update(int Id, Poll request)
    {
        var IsUpdated = _pollService.Update(Id, request);

        if (!IsUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var IsDeleted = _pollService.Delete(Id);

        if (!IsDeleted)
            return NotFound();

        return NoContent();
    }
}

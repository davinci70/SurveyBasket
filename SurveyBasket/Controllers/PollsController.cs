
using MapsterMapper;

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService, IMapper mapper) : ControllerBase
{
    private readonly IPollService _pollService = pollService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        var polls = _pollService.GetAll();

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
    }
    
    [HttpGet("{Id}")]
    public IActionResult GetById([FromRoute]int Id)
    {
        var poll = _pollService.Get(Id);

        if (poll is null)
            return NotFound();

        var response = _mapper.Map<PollResponse>(poll);

        return poll is null ? NotFound() : Ok(response);
    }

    [HttpPost("")]
    public IActionResult Add([FromBody]CreatePollRequest request)
    {
        var newPoll = _pollService.Add(request.Adapt<Poll>());

        return CreatedAtAction(nameof(GetById), new { Id = newPoll.Id }, newPoll);
    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromRoute]int Id, [FromBody] CreatePollRequest request)
    {
        var IsUpdated = _pollService.Update(Id, request.Adapt<Poll>());

        if (!IsUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete([FromRoute] int Id)
    {
        var IsDeleted = _pollService.Delete(Id);

        if (!IsDeleted)
            return NotFound();

        return NoContent();
    }
}

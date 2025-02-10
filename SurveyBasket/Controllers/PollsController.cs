
using MapsterMapper;
using SurveyBasket.Services.IService;

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService, IMapper mapper) : ControllerBase
{
    private readonly IPollService _pollService = pollService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var polls = await _pollService.GetAllAsync(cancellationToken);

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var poll = await _pollService.GetAsync(Id, cancellationToken);

        if (poll is null)
            return NotFound();

        var response = _mapper.Map<PollResponse>(poll);

        return poll is null ? NotFound() : Ok(response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var newPoll = await _pollService.AddAsync(request.Adapt<Poll>(), cancellationToken);

        return CreatedAtAction(nameof(Get), new { Id = newPoll.Id }, newPoll);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var IsUpdated = await _pollService.UpdateAsync(Id, request.Adapt<Poll>(), cancellationToken);

        if (!IsUpdated)
            return NotFound();

        return NoContent();
    }
    
    [HttpPut("{Id}/togglePublish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var poll = await _pollService.TogglePublishStatusAsync(Id, cancellationToken);

        if (!poll)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var IsDeleted = await _pollService.DeleteAsync(Id, cancellationToken);

        if (!IsDeleted)
            return NotFound();

        return NoContent();
    }
}

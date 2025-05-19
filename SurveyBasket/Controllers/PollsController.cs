
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using SurveyBasket.Contracts.Polls;
using SurveyBasket.Services.IService;

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class PollsController(IPollService pollService, IMapper mapper) : ControllerBase
{
    private readonly IPollService _pollService = pollService;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    [HasPermission(Permissions.GetPolls)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _pollService.GetAllAsync(cancellationToken));
    }
    
    [HttpGet("Current")]
    public async Task<IActionResult> GetCurrent(CancellationToken cancellationToken)
    {
        return Ok(await _pollService.GetCurrentAsync(cancellationToken));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _pollService.GetAsync(Id, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.ToProplem();
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var result = await _pollService.AddAsync(request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new { id = result.Value.Id }, result.Value)
            : result.ToProplem();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var result = await _pollService.UpdateAsync(Id, request, cancellationToken);

        return result.IsSuccess 
            ? NoContent() 
            : result.ToProplem();
    }

    [HttpPut("{Id}/toggle-publish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _pollService.TogglePublishStatusAsync(Id, cancellationToken);

        return result.IsSuccess 
            ? NoContent() 
            : result.ToProplem();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var result = await _pollService.DeleteAsync(Id, cancellationToken);

        return result.IsSuccess 
            ? NoContent() 
            : result.ToProplem();
    }
}

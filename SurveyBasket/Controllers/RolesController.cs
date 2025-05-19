using SurveyBasket.Contracts.Roles;

namespace SurveyBasket.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet("")]
    [HasPermission(Permissions.GetPolls)]
    public async Task<IActionResult> GetAll([FromQuery] bool includeDisabled, CancellationToken cancellationToken)
    {
        return Ok(await _roleService.GetAllAsync(includeDisabled, cancellationToken));
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.GetPolls)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _roleService.GetAsync(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProplem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddRoles)]
    public async Task<IActionResult> Add([FromBody] RoleRequest request)
    {
        var result = await _roleService.AddAsync(request);

        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProplem();
    }

    [HttpPut("")]
    [HasPermission(Permissions.UpdateRoles)]
    public async Task<IActionResult> update([FromRoute] string Id, [FromBody] RoleRequest request)
    {
        var result = await _roleService.UpdateAsync(Id, request);

        return result.IsSuccess ? NoContent() : result.ToProplem();
    }

    [HttpPut("{Id}/toggle-status")]
    [HasPermission(Permissions.UpdateRoles)]
    public async Task<IActionResult> ToggleStatus([FromRoute] string Id)
    {
        var result = await _roleService.ToggleStatusAsync(Id);

        return result.IsSuccess ? NoContent() : result.ToProplem();
    }
}

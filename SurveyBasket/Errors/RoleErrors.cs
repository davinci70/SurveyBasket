namespace SurveyBasket.Errors;

public class RoleErrors
{
    public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "Role is not found", StatusCodes.Status404NotFound);
    
    public static readonly Error DublicatedRole =
        new("Role.DublicatedRole", "Another role with the same name is already exists", StatusCodes.Status409Conflict);
    
    public static readonly Error InvalidPermissions =
        new("Role.InvalidPermissions", "Invalid permissions", StatusCodes.Status400BadRequest);
}

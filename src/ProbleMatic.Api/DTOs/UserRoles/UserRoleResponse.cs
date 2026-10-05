namespace ProbleMatic.Api.DTOs.UserRoles;

public record UserRoleResponse(Guid Id, Guid UserId, Guid RoleId, DateTime CreatedAt);

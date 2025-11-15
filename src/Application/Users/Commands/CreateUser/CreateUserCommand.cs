using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommand : IRequest<Guid>
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
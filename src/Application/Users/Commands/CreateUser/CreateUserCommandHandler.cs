using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guid newUserId = Guid.NewGuid();

        // Simulate some asynchronous operation
        await Task.Delay(100, cancellationToken);

        return newUserId;
    }
}
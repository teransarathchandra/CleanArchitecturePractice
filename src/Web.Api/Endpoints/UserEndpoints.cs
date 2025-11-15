using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetAllUsers;
using FluentValidation;
using MediatR;

namespace Web.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapPost("/users", async (CreateUserCommand command, IMediator mediator, IValidator<CreateUserCommand> validator) =>
        {
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            Guid newUserId = await mediator.Send(command);
            return Results.Created($"/users/{newUserId}", new { Id = newUserId });
        });

        app.MapGet("/users", async Task<IResult> (IMediator mediator, CancellationToken ct) =>
        {
            var query = new GetAllUsersQuery();
            var users = await mediator.Send(query, ct);

            return Results.Ok(users);
        });
    }
}
using Domain.Entities;
using MediatR;

namespace Application.Users.Queries.GetAllUsers;

public sealed class GetAllUsersQuery : IRequest<IList<User>>;
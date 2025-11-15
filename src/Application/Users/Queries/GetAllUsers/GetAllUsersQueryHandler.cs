using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Queries.GetAllUsers;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<User>>
{
    private readonly IUserRepository _userRepository;
    
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    } 

    public async Task<IList<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IList<User> users = await _userRepository.GetAllAsync(cancellationToken);

        return users;
    }
}
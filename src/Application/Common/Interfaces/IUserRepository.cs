using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IUserRepository
{
    Task<IList<User>> GetAllAsync(CancellationToken cancellationToken);
}
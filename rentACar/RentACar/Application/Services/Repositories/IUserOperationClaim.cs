using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaim : IAsyncRepository<UserOperationClaim, int>
    , IRepository<UserOperationClaim, int>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}
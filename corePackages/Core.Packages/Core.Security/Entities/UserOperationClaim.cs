using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserOperationClaim:Entity<int>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual User user { get; set; }

        public virtual OperationClaim operationClaim { get; set; }
        public UserOperationClaim()
        {
        }
        public UserOperationClaim(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
        public UserOperationClaim(int id, int userId, int operationClaimId) : base(id)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}

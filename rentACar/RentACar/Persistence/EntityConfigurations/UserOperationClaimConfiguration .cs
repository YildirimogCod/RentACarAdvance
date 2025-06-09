using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

            builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
            builder.Property(uoc => uoc.CreatedAt).HasColumnName("CreatedDate").IsRequired();
            builder.Property(uoc => uoc.UpdatedAt).HasColumnName("UpdatedDate");
            builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

            builder.HasOne(uoc => uoc.user);
            builder.HasOne(uoc => uoc.operationClaim);

            builder.HasData(getSeeds());
        }

        private IEnumerable<UserOperationClaim> getSeeds()
        {
            List<UserOperationClaim> userOperationClaims = new();

            UserOperationClaim adminUserOperationClaim = new(id: 1, userId: 1, operationClaimId: 1);
            userOperationClaims.Add(adminUserOperationClaim);

            return userOperationClaims;
        }
    }
}

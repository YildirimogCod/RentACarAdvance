﻿using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
            builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
            builder.Property(oc => oc.CreatedAt).HasColumnName("CreatedDate").IsRequired();
            builder.Property(oc => oc.UpdatedAt).HasColumnName("UpdatedDate");
            builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

            builder.HasMany(oc => oc.UserOperationClaims);

            //builder.HasData(_seeds);
        }
    }
}

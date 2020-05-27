﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");

            builder.Property(u => u.Id).UseIdentityColumn().IsRequired().HasColumnName("ID");

            builder.Property(u => u.Deleted).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("DELETED");

            builder.Property(u => u.Name).IsRequired().HasColumnType("VARCHAR(100)").HasColumnName("NAME");

            builder.Property(u => u.Email).HasMaxLength(100).HasColumnType("VARCHAR(100)").IsRequired().HasColumnName("EMAIL");
            builder.HasIndex(u => u.Email).IsUnique(true);

            builder.Property(u => u.Password).HasMaxLength(16).HasColumnType("VARCHAR(16)").IsRequired().HasColumnName("PASSWORD");

            builder.Property(u => u.IsAdmin).IsRequired().HasDefaultValue(false).HasColumnType("BIT").HasColumnName("IS_ADMIN");
        }
    }
}
﻿using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Configuration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasMany(p => p.Roles)
            .WithMany(p => p.Users)
            .UsingEntity("UsersRoles");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Email)
            .IsRequired(true)
            .IsUnicode(true);
        
        builder.Property(p => p.CompleteName)
            .IsRequired(true);

        builder.Property(p => p.PasswordHash)
            .IsRequired(true)
            .IsUnicode(true);

        builder.Property(p => p.Company)
            .IsRequired(false);

        builder.Property(p => p.Country)
            .IsRequired(false);

        builder.Property(p => p.PasswordSalt)
            .IsUnicode(true)
            .IsRequired(true);
    }
}
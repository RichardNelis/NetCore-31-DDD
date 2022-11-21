using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UserSeeds
    {
        public static void Users(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "souza.richard33@hotmail.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                }
            );
        }
    }
}

using DotNetChatApp.Model.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Context.ModelCreatings.Users
{
    public class UserModelCreating
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            GetBuilder(modelBuilder).ToTable("users");
            
            GetBuilder(modelBuilder).HasKey(u => u.Id);
            GetBuilder(modelBuilder).Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType<long>("bigint")
                .IsRequired();

            GetBuilder(modelBuilder).Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType<string>("varchar(128)")
                .IsRequired();

            GetBuilder(modelBuilder).Property(u => u.Password)
                .HasColumnName("password")
                .HasColumnType<string>("varchar(255)")
                .IsRequired();
        }

        private static EntityTypeBuilder<User> GetBuilder(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<User>();
        }

    }
}

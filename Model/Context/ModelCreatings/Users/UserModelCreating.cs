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
            // table users
            GetBuilder(modelBuilder).ToTable("users");
            // primary key 
            GetBuilder(modelBuilder).HasKey(u => u.Id);
            
            GetBuilder(modelBuilder).Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType<long>("bigint")
                .IsRequired();

            // email column
            GetBuilder(modelBuilder).Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType<string>("varchar(128)")
                .IsRequired();
            
            // password column
            GetBuilder(modelBuilder).Property(u => u.Password)
                .HasColumnName("password")
                .HasColumnType<string>("varchar(255)")
                .IsRequired();
            
            // this is to be ignored / transient***
            GetBuilder(modelBuilder).Ignore(u => u.Message);
        }

        private static EntityTypeBuilder<User> GetBuilder(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<User>();
        }

    }
}

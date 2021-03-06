﻿using DotNetChatApp.Model.Entity.Messages;
using DotNetChatApp.Model.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Context.ModelCreatings.Messages
{
    public class MessageModelCreating
    {

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {

            // table name
            GetBuilder(modelBuilder).ToTable("messages");

            // primary key
            GetBuilder(modelBuilder).HasKey(u => u.Id);
            GetBuilder(modelBuilder).Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType<long>("bigint")
                .IsRequired();
            // sender id foreign key
            GetBuilder(modelBuilder)
                .HasOne(m => m.Sender)
                .WithOne()
                .HasForeignKey<Message>(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
            // recipient id foreign key
            GetBuilder(modelBuilder)
                .HasOne(m => m.Recipient)
                .WithOne()
                .HasForeignKey<Message>(m => m.RecipientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasPrincipalKey<User>(u => u.Id);
            // the message 
            GetBuilder(modelBuilder).Property(m => m.TheMessage)
                .HasColumnName("the_message")
                .HasColumnType<string>("text")
                .IsRequired();
            // date and time of sending the message
            GetBuilder(modelBuilder).Property(m => m.TheDateAndTime)
                .HasColumnName("date_time")
                .HasColumnType("datetime DEFAULT GETDATE()")
                .IsRequired();
        }

        private static EntityTypeBuilder<Message> GetBuilder(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Message>();
        }

    }
}

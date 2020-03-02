﻿// <auto-generated />
using System;
using DotNetChatApp.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetChatApp.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    [Migration("20200301221959_UserAndMessage")]
    partial class UserAndMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetChatApp.Model.Entity.Messages.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TheDateAndTime")
                        .HasColumnName("date_time")
                        .HasColumnType("datetime DEFAULT GETDATE()");

                    b.Property<string>("TheMessage")
                        .IsRequired()
                        .HasColumnName("the_message")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId")
                        .IsUnique();

                    b.HasIndex("SenderId")
                        .IsUnique();

                    b.ToTable("messages");
                });

            modelBuilder.Entity("DotNetChatApp.Model.Entity.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(128)");

                    b.Property<long?>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DotNetChatApp.Model.Entity.Messages.Message", b =>
                {
                    b.HasOne("DotNetChatApp.Model.Entity.Users.User", "Recipient")
                        .WithOne()
                        .HasForeignKey("DotNetChatApp.Model.Entity.Messages.Message", "RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetChatApp.Model.Entity.Users.User", "Sender")
                        .WithOne()
                        .HasForeignKey("DotNetChatApp.Model.Entity.Messages.Message", "SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetChatApp.Model.Entity.Users.User", b =>
                {
                    b.HasOne("DotNetChatApp.Model.Entity.Messages.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");
                });
#pragma warning restore 612, 618
        }
    }
}

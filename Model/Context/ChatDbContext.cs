using DotNetChatApp.Model.Context.ModelCreatings.Users;
using DotNetChatApp.Model.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Context
{
    public class ChatDbContext :  DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            UserModelCreating.OnModelCreating(modelBuilder);
        }

    }
}

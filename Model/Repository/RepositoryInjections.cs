using DotNetChatApp.Model.Entity.Messages;
using DotNetChatApp.Model.Entity.Users;
using DotNetChatApp.Model.Repository.Messages;
using DotNetChatApp.Model.Repository.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Repository
{
    public class RepositoryInjections
    {
        public static void InjectedRepositories(IServiceCollection services)
        {
            
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Message>, MessageRepository>();

        }
    }
}

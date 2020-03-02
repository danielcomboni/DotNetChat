using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetChatApp.Model.Entity.Users;
using DotNetChatApp.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChatApp.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Repository<User>
    {
        private readonly IRepository<User> _context;

        public UserController(IRepository<User> repository)
        {
            _context = repository;
        }

        [HttpPost]
        public override Task<ActionResult<User>> Add(User entityObject)
        {
            return _context.Add(entityObject);
        }

        [HttpGet]
        public override Task<ActionResult<IEnumerable<User>>> FindAll()
        {
            return _context.FindAll();
        }

        [HttpGet("{id}")]
        public override Task<ActionResult<User>> FindById(long id)
        {
            return _context.FindById(id);
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<User>> Update(long id, User entityObject)
        {
            return _context.Update(id, entityObject);
        }

        [HttpDelete("{id}")]
        public override Task<ActionResult<User>> Remove(long id)
        {
            return _context.Remove(id);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetChatApp.Model.Entity.Messages;
using DotNetChatApp.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChatApp.Controllers.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Repository<Message>
    {
        private readonly IRepository<Message> _context;

        public MessageController(IRepository<Message> repository)
        {
            _context = repository;
        }

        [HttpPost]
        public override Task<ActionResult<Message>> Add(Message entityObject)
        {
            return _context.Add(entityObject);
        }

        [HttpGet]
        public override Task<ActionResult<IEnumerable<Message>>> FindAll()
        {
            return _context.FindAll();
        }

        [HttpGet("{id}")]
        public override Task<ActionResult<Message>> FindById(long id)
        {
            return _context.FindById(id);
        }

        [HttpPut("{id}")]
        public override Task<ActionResult<Message>> Update(long id, Message entityObject)
        {
            return _context.Update(id, entityObject);
        }

        [HttpDelete("{id}")]
        public override Task<ActionResult<Message>> Remove(long id)
        {
            return _context.Remove(id);
        }

    }
}
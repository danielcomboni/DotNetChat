using DotNetChatApp.Model.Context;
using DotNetChatApp.Model.Entity.Messages;
using DotNetChatApp.Model.Entity.Users;
using DotNetChatApp.Model.Repository.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetChatApp.Model.Repository.Users;


namespace DotNetChatApp.Model.Repository.Messages
{
    public class MessageRepository : ControllerBase, IRepository<Message>
    {
        private readonly ChatDbContext _context;

        private readonly IRepository<User> _contextUser;

        public MessageRepository(ChatDbContext chatDbContext, IRepository<User> userRepository)
        {

            _context = chatDbContext;
            _contextUser = userRepository;
            
        }

        private  async Task<ActionResult<User>> FindUserByIdAsync(long id)
        {
            return await _contextUser.FindById(id);
        }

        public async Task<ActionResult<Message>> Add(Message entityObject)
        {

            entityObject.TheDateAndTime = DateUtils.GetCurrentDateTime();
            ActionResult<User> aRecipient = await FindUserByIdAsync(entityObject.RecipientId);
            ActionResult<User> aSender= await FindUserByIdAsync(entityObject.SenderId);

            _context.Messages.Add(entityObject);
            await _context.SaveChangesAsync();

            entityObject.Sender = aSender.Value;
            entityObject.Recipient = aRecipient.Value;

            return CreatedAtAction(nameof(FindById), new { id = entityObject.Id }, entityObject);

        }

        public async Task<ActionResult<IEnumerable<Message>>> FindAll()
        {
            List<Message> messages = await _context.Messages.ToListAsync();

            foreach (Message message in messages)
            {

                ActionResult<User> aRecipient = await _contextUser.FindById(message.RecipientId);
                message.Recipient = aRecipient.Value;

                ActionResult<User> aSender = await _contextUser.FindById(message.SenderId);
                message.Sender = aSender.Value;
            }

            return await _context.Messages.ToListAsync();
        }

        public async Task<ActionResult<Message>> FindById(long id)
        {
            var entitytObject = await _context.Messages.FindAsync(id);
            if (entitytObject == null)
            {
                return NotFound();
            }
            else
            {
                return entitytObject;
            }

        }

        public async Task<ActionResult<Message>> Remove(long id)
        {
            var entitytObject = await _context.Messages.FindAsync(id);

            if (entitytObject == null)
            {
                return NotFound();
            }
            else
            {
                _context.Messages.Remove(entitytObject);
                await _context.SaveChangesAsync();
                return entitytObject;
            }
        }

        public bool TEntityExists(long id)
        {
            return _context.Messages.Any(entityObject => entityObject.Id == id);
        }

        public async Task<ActionResult<Message>> Update(long id, Message entityObject)
        {

            if (id != entityObject.Id)
            {
                return BadRequest();
            }

            else if (!TEntityExists(id))
            {
                return NotFound();
            }

            else
            {
                _context.Entry(entityObject).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(FindById), new { id = entityObject.Id }, entityObject);

            }
        }

    }


}

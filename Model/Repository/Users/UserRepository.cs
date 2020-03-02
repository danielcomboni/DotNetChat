using DotNetChatApp.Model.Context;
using DotNetChatApp.Model.Entity.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Repository.Users
{
    public class UserRepository : ControllerBase, IRepository<User>
    {

        private readonly ChatDbContext _context;

        public UserRepository(ChatDbContext chatDbContext)
        {
            _context = chatDbContext;
        }

        public async Task<ActionResult<User>> Add(User entityObject)
        {
            _context.Users.Add(entityObject);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(FindById), new { id = entityObject.Id}, entityObject);
        }

        public async Task<ActionResult<IEnumerable<User>>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> FindById(long id)
        {
            var entitytObject = await _context.Users.FindAsync(id);
            if (entitytObject == null )
            {
                return NotFound();
            }
            else
            {
                return entitytObject;
            }
            
        }

        public async Task<ActionResult<User>> Remove(long id)
        {
            var entitytObject = await _context.Users.FindAsync(id);

            if (entitytObject == null)
            {
                return NotFound();
            }
            else
            {
                _context.Users.Remove(entitytObject);
                await _context.SaveChangesAsync();
                return entitytObject;
            }
        }

        public bool TEntityExists(long id)
        {
            return _context.Users.Any(entityObject => entityObject.Id == id);
        }

        public async Task<ActionResult<User>> Update(long id, User entityObject)
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

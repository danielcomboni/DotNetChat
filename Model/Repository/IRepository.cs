using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Repository
{
    public interface IRepository<TEntity>
    {
        public Task<ActionResult<TEntity>> Add(TEntity entityObject);
        public Task<ActionResult<IEnumerable<TEntity>>> FindAll();
        public Task<ActionResult<TEntity>> FindById(int id);
        public Task<ActionResult<TEntity>> Remove(int id);
        public bool TEntityExists(int id);
        public Task<ActionResult<TEntity>> Update(int id, TEntity entityObject);

    }
}

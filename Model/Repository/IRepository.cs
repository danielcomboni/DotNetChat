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
        public Task<ActionResult<TEntity>> FindById(long id);
        public Task<ActionResult<TEntity>> Remove(long id);
        public bool TEntityExists(long id);
        public Task<ActionResult<TEntity>> Update(long id, TEntity entityObject);

    }
}

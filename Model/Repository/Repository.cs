using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {
        
        public virtual Task<ActionResult<TEntity>> Add(TEntity entityObject)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<IEnumerable<TEntity>>> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public virtual bool TEntityExists(long id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> Update(long id, TEntity entityObject)
        {
            throw new NotImplementedException();
        }
    }

}

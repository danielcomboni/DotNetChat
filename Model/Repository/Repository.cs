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

        public virtual Task<ActionResult<TEntity>> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public virtual bool TEntityExists(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> Update(int id, TEntity entityObject)
        {
            throw new NotImplementedException();
        }
    }

}

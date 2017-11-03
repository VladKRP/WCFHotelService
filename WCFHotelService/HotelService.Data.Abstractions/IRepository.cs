using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelService.Data.Abstractions
{
    public interface IRepository<Entity, key> : IDisposable
    {
        Entity Get(key id);
        IQueryable<Entity> GetAll();
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}

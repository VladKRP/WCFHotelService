using HotelService.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace HotelService.Data
{
    public class Repository<Entity> : IRepository<Entity, int> where Entity : class
    {
        protected HotelAppContext _context;
        private DbSet<Entity> dbSet;

        public Repository(){
            _context = new HotelAppContext();
            dbSet = _context.Set<Entity>();
        }

        public virtual Entity Get(int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual IEnumerable<Entity> GetAll()
        {
            return dbSet;
        }

        public virtual IQueryable<Entity> GetAllQueryable()
        {
            return dbSet;
        }

        public virtual void Create(Entity entity)
        {
             dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(Entity entity)
        {
              _context.Entry<Entity>(entity).State = EntityState.Modified;
              _context.SaveChanges();
        }

        public virtual void Delete(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                    _context.Dispose();
            }
            disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(_context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Repository
{
    public class DbRepositorySQL<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        // 
        private TeaShopContext _contextDb;
        // набор для работы с ТЕКУЩЕЙ сущностью
        private DbSet<TEntity> _dbSet;

        public DbRepositorySQL(TeaShopContext context)
        {
            _contextDb = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetList()
        {
            // Use AsNoTracking() for NPT CACHING
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetNote(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity note)
        {
            _dbSet.Add(note);
            _contextDb.SaveChanges();
        }

        public void Update(TEntity note, Guid id)
        {
            TEntity noteExisting = _dbSet.Find(id);
            try
            {
                if (noteExisting != null)
                {
                    _contextDb.Entry(noteExisting).CurrentValues.SetValues(note);
                    //_contextDb.Entry(note).State = EntityState.Modified;
                    _contextDb.SaveChanges();
                }
                    
            }
            catch
            {

            }
        }

        public void Delete(Guid id)
        {
            TEntity note = _dbSet.Find(id);
            if (note != null)
                _dbSet.Remove(note);
        }

        public void Remove(TEntity note)
        {
            _dbSet.Remove(note);
            _contextDb.SaveChanges();
        }

        public void Save()
        {
            _contextDb.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contextDb.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
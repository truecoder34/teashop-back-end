using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITeaApp.Repository
{
    interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity GetNote(Guid id);
        void Create(TEntity note);
        void Update(TEntity note);
        void Remove(TEntity note);
        void Delete(Guid id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}

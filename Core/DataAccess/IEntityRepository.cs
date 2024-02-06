using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess;

// Generic Repository Oluşturma
// IEntityRepository<T> where T : class, IEntity, new()  --- IEntity referans alan'da diyebiliriz.
public interface IEntityRepository<T> where T : class
{
    // Id'ye göre getir
    T Get(Expression<Func<T,bool>> filter);

    // Filtreye Göre Getir
    IList<T> GetAll(Expression<Func<T, bool>> filter=null);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}

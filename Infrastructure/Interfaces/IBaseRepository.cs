using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepository< T> where T : class
    {
        //DbSet<T> DbSet { get; set; }
        void Detached(T entity);
        int Count();
        T GetById(Guid id);
        IEnumerable<T> Pagination(IQueryable<T> values, int page, int range);
        T GetById(string id);
        void Add(T entity);
        void SaveChanges();
        void Update(T entity);
        void Delete(T entity);
    }
}

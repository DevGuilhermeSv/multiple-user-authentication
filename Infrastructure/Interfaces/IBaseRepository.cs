using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepository< T> where T : class
    {
        DbSet<T?> DbSet { get; set; }
        T? GetById(Guid id);
        T? GetById(string id);
        void Add(T? entity);
        void SaveChanges();
        void Update(T entity);
        void Delete(T? entity);
        IQueryable<T> GetAll();

    }
}

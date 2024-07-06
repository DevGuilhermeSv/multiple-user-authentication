using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public DbSet<T> DbSet { get; set; }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Detached(T entity)
        {
            DbSet.Entry(entity).State = EntityState.Detached;
        }


        public T? GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public T? GetById(string id)
        {
            return DbSet.Find(id);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

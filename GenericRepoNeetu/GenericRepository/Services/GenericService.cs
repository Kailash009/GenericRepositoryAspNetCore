using GenericRepoNeetu.GenericRepository.Contract;
using GenericRepoNeetu.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepoNeetu.GenericRepository.Services
{
    public class GenericService<T> : IGeneric<T> where T : class
    {
        private readonly GenericDbContext _dbContext;
        private readonly DbSet<T> _entity;
        public GenericService(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return _entity.ToList();
        }
        public bool Add(T obj)
        {
            _entity.Add(obj);
            int n = _dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T Get(int id)
        {
            T t=_entity.Find(id);
            if(t!=null)
            {
                return t;
            }
            return null;
        }
        public bool Update(T obj)
        {
            _entity.Update(obj);
            int n = _dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var T = _entity.Find(id);
            _entity.Remove(T);
            int n = _dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

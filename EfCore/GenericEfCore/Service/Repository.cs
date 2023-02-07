using EfCore;
using EntityFramework.GenericEfCore.Contract;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.GenericEfCore.Service
{
    public class Repository<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly ProjectDbContext _context;

        public Repository(ProjectDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            using (_context)
            {
                try
                {

                    _context.Set<T>().Add(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public void Delete(Tkey id)
        {
            using (_context)
            {
                try
                {
                    var entity = _context.Set<T>().Find(id);
                    _context.Entry(entity).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public T Get(Tkey id)
        {
            using (_context)
            {
                try
                {
                    return _context.Set<T>().Find(id);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public List<T> GetAll()
        {
            using (_context)
            {
                try
                {

                    return _context.Set<T>().ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }

        public void Update(T entity)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
    }
}

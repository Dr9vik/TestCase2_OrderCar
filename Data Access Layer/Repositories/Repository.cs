using Data_Access_Layer.Common.Repositories;
using Data_Access_Layer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create<T>(T item) where T : class
        {
            _context.Set<T>().Add(item);
        }

        public void Update<T>(T item) where T : class
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void UpdateAll<T>(IList<T> items) where T : class
        {
            while (items.Count > 0)
            {
                _context.Entry(items[0]).State = EntityState.Modified;
            }
        }

        public void Delete<T>(string id) where T : class
        {
            var group = _context.Set<T>().Find(id);
            if (group != null)
                _context.Set<T>().Remove(group);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public void DeleteAll<T>(IList<T> items) where T : class
        {
            while (items.Count > 0)
            {
                _context.Entry(items[0]).State = EntityState.Deleted;
            }
        }
        public Task<IQueryable<T>> Sql<T>(string item) where T : class
        {
            return Task.FromResult(_context.Set<T>().FromSql(item));
        }
        public Task<IQueryable<R>> Join<T, U, R>(Expression<Func<T, object>> predicateInner,
            Expression<Func<U, object>> predicateOuter, Expression<Func<T, U, R>> resultSelector) where T : class where U : class where R : class
        {
            return Task.FromResult(_context.Set<T>().Join(_context.Set<U>(), predicateInner, predicateOuter, resultSelector));
        }

        public Task<T> Get<T>(string id) where T : class
        {
            return Task.FromResult(_context.Set<T>().Find(id));
        }

        public Task<IList<T>> GetAll<T>() where T : class
        {
            IList<T> query = _context.Set<T>().ToList();
            return Task.FromResult(query);
        }

        public Task<IQueryable<T>> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return Task.FromResult(query);
        }

        public Task<IQueryable<T>> GetWithInclude<T>(
            params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return Task.FromResult(Include(includeProperties));
        }

        public Task<IQueryable<T>> GetWithInclude<T>(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties) where T : class
        {

            return Task.FromResult(Include(includeProperties).Where(predicate));
        }

        public Task<IQueryable<T>> GetWithThenInclude<T>(Func<IQueryable<T>, IQueryable<T>> includeMembers) where T : class
        {
            return Task.FromResult(includeMembers(_context.Set<T>()));
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }

        private IQueryable<T> Include<T>(
            params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, func: (current, includeProperty) => current.Include(includeProperty));
        }

        ~Repository()
        {
            Dispose();
        }
    }
}

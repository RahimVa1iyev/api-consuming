using CourseApp.Core.Repositories;
using CourseApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CourseDbContext _context;

        public Repository(CourseDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity group)
        {
            _context.Set<TEntity>().Add(group); ;
        }

        public TEntity Get(Func<TEntity, bool> exp , params string[] includes)
        {
            
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes!=null && includes.Length>0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault(exp);
        }

        public IQueryable<TEntity> GetQueryable(Func<TEntity, bool> exp ,params string[] includes )
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query.AsQueryable();
        }

        public int IsCommit()
        {
             return _context.SaveChanges();
        }

        public bool IsExist(Func<TEntity, bool> exp)
        {
           return  _context.Set<TEntity>().Any(exp);
        }

        public void Remove(TEntity group)
        {
            _context.Set<TEntity>().Remove(group);
        }
    }
}

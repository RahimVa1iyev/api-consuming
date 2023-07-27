using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Core.Repositories
{
    public interface IRepository<TEntity>
    {

        TEntity Get(Func<TEntity, bool> exp, params string[] includes);

        IQueryable<TEntity> GetQueryable(Func<TEntity, bool> exp, params string[] includes);

        bool IsExist(Func<TEntity, bool> exp);

        void Add(TEntity group);

        void Remove(TEntity group);

        int IsCommit();
    }
}

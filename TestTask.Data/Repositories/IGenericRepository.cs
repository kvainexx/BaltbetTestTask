using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        DataContext.DataContext Context { get; set; }

        TEntity GetByID(object id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Table(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");


        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Save(bool useTracking = true);

    }
}

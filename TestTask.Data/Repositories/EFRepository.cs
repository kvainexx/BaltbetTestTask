using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TestTask.Data.UnitOfWork.Abstract;

namespace TestTask.Data.Repositories
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : class
    {
        private DataContext.DataContext context;
        private IUnitOfWork unitOfWork;
        private IDbSet<TEntity> dbSet;


        public EFRepository(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork.GetContext();
            this.dbSet = context.Set<TEntity>();
            this.unitOfWork = unitOfWork;
        }

        public DataContext.DataContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
                dbSet = context.Set<TEntity>();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table().ToList();
        }

        public virtual IQueryable<TEntity> QueryableDbSet
        {
            get
            {
                IQueryable<TEntity> query = dbSet;
                return query;
            }
        }


        public virtual IQueryable<TEntity> Table(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = QueryableDbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query);

            return query;
        }


        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }


        public void Save(bool useTracking = true)
        {
            if (useTracking)
                this.context.ChangeTracker.DetectChanges();
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                StringBuilder ss = new StringBuilder();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        ss.AppendFormat("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }

                var str = ss.ToString();
            }



        }


        private bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {

                }
                this.unitOfWork.Dispose();
                context.Dispose();
            }
            this.isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

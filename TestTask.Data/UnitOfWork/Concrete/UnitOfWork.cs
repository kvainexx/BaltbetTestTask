using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : Abstract.IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private DataContext.DataContext _context;

        public DataContext.DataContext GetContext()
        {
            return _context;
        }

        public UnitOfWork()
        {
            _context = new DataContext.DataContext();
        }
        public void Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            var _databaseContext = GetContext();
            _databaseContext.ChangeTracker.DetectChanges();
            _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            DataContextManager.DisposeCurrentContext();

            _disposed = true;
        }
    }
}

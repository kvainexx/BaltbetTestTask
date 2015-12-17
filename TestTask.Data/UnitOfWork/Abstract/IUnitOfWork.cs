using System;

namespace TestTask.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext.DataContext GetContext();

        void Commit();
    }
}

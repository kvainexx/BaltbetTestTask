
using System.Threading;
using System.Web;

namespace TestTask.Data.UnitOfWork
{
    public static class DataContextManager
    {
        private static string Key
        {
            get
            {
                return string.Format("MyDb_{0}{1}", HttpContext.Current.GetHashCode().ToString("x"), Thread.CurrentContext.ContextID);
            }
        }

        private static DataContext.DataContext Context
        {
            get
            {
                return HttpContext.Current.Items[Key] as DataContext.DataContext;
            }
            set
            {
                HttpContext.Current.Items[Key] = value;
            }
        }

        public static void CrateCurrentContext()
        {
            if (Context == null)
            {
                Context = new DataContext.DataContext();
                HttpContext.Current.Items[Key] = Context;
            }
        }

        public static DataContext.DataContext Current
        {
            get
            {
                if (Context == null)
                {
                    Context = new DataContext.DataContext();
                    HttpContext.Current.Items[Key] = Context;
                }
                return Context;
            }
        }

        public static void DisposeCurrentContext()
        {
            if (Context != null)
            {
                Context.Dispose();
                HttpContext.Current.Items[Key] = null;
            }
        }
    }
}

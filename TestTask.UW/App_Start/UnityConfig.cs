using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using TestTask.Data.UnitOfWork.Abstract;
using TestTask.Data.UnitOfWork.Concrete;
using TestTask.Services.Methods.Public.Directories.Abstract;
using TestTask.Services.Methods.Public.Directories.Concrete;
using TestTask.Services.Methods.Public.Records.Concrete;
using TestTask.Services.Methods.Public.Records.Abstract;

namespace TestTask.UW.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion


        static void CreateRepositoryInjection<T>(ref IUnityContainer container)
               where T : class
        {
            container.RegisterType<Data.Repositories.IGenericRepository<T>, Data.Repositories.EFRepository<T>>();
        }

        static void CreateServiceInjection<TFrom, TTo>(ref IUnityContainer container)
            where TFrom : class
            where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>();
        }


        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            #region Repository
            CreateRepositoryInjection<Data.Entities.Directory>(ref container);
            CreateRepositoryInjection<Data.Entities.Record>(ref container);
            #endregion

            CreateServiceInjection<IDirectoriesService, DirectoriesService>(ref container);
            CreateServiceInjection<IRecordsService, RecordsService>(ref container);
        }
    }
}

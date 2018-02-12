using System;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Interfaces;
using StairEstate.Repo;
using StairEstate.Repo.Generics;
using StairEstate.Service;
using Unity;

namespace StaitEstate.View
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();


            //DbContext
            container.RegisterType<MHLDB, MHLDB>();

            //For Menu
            container.RegisterType<IMenuRepository, MenuRepository>();
            container.RegisterType<IMenuService, MenuService>();
            container.RegisterType<IRepository<sys_menu>, Repository<sys_menu>>();

            //For User
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRepository<sys_user>, Repository<sys_user>>();


            //For User Type
            container.RegisterType<IUserTypeService, UserTypeService>();
            container.RegisterType<IUserTypeRepository, UserTypeRepository>();
            container.RegisterType<IRepository<sys_user_type>, Repository<sys_user_type>>();

        }
    }
}
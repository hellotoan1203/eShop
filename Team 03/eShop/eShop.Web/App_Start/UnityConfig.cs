using eShop.Data.Repositories;
using eShop.Service.Services;
using System;

using Unity;

namespace eShop.Web
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
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<ICartService, CartService>();

            container.RegisterType<ICartItemRepository, CartItemRepository>();
            container.RegisterType<ICartItemService, CartItemService>();

            container.RegisterType<IErrorRepository, ErrorRepository>();
            container.RegisterType<IErrorService, ErrorService>();

            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IOrderService, OrderService>();

            container.RegisterType<IOrderNumberRepository, OrderNumberRepository>();
            container.RegisterType<IOrderNumberService, OrderNumberService>();

            container.RegisterType<IOrderDetailRepository, OrderDetailRepository>();
            container.RegisterType<IOrderDetailService, OrderDetailService>();

            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductService, ProductService>();

            container.RegisterType<IArtistRepository, ArtistRepository>();
            container.RegisterType<IArtistService, ArtistService>();

            container.RegisterType<IRatingRepository, RatingRepository>();
            container.RegisterType<IRatingService, RatingService>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IAdHocRepository, AdHocRepository>();
            container.RegisterType<IAdHocService, AdHocService>();

        }
    }
}
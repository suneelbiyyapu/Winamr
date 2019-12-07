using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using winamr.Contracts.Repository;
using winamr.Contracts.Services.Data;
using winamr.Contracts.Services.General;
using winamr.Repository;
using winamr.Services;
using winamr.Services.Data;
using winamr.Services.General;
using winamr.ViewModels;

namespace winamr.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register All ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<RegistrationViewModel>();

            // Register all data services
            // builder.RegisterType<CatalogDataService>().As<ICatalogDataService>();
            // builder.RegisterType<ShoppingCartDataService>().As<IShoppingCartDataService>();
            // builder.RegisterType<ContactDataService>().As<IContactDataService>();
            // builder.RegisterType<OrderDataService>().As<IOrderDataService>();

            // Register all general services
            builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            //General
            builder.RegisterType<GenericRepositary>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

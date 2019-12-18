[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UserManagement.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(UserManagement.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace UserManagement.WebAPI.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using System.Web.Http.Filters;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;
    using UserManagement.Api.Domain;
    using UserManagement.API.Repositories;
    using UserManagement.WebAPI.AuthenticationFilter;
    using UserManagement.WebAPI.Filters;
    using UserManagement.WebAPI.Helpers;
    using UserManagementAPI.Interfaces;
    using UserManagementAPI.Repository;
    using UserManagementAPI.UnitOfWork;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                var httpResolver = new NinjectHttpDependencyResolver(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = httpResolver;
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<UserManagementContext>();
            kernel.Bind<IDeserializer, ISerializer>().To<RepositorySerializer>().InSingletonScope();
            kernel.Bind<ICacheService>().To<RepositoryMemoryCache>();

            kernel.Bind<IUserServices>().To<RepositoryUserServices>();
            kernel.Bind(typeof(RestClient)).To(typeof(RepositoryClient));
            kernel.Bind<RepositoryClient, IUser>().To<UserRepository>();

            //kernel.Bind<ActionFilterAttribute>().To<LoggingFilterAttribute>();
            //kernel.Bind<ExceptionFilterAttribute>().To<GlobalExceptionAttribute>();

            kernel.Bind<Exception, IApiExceptions>().To<ApiBusinessException>().InSingletonScope();
            kernel.Bind<Exception, IApiExceptions>().To<ApiDataException>().InSingletonScope();
            kernel.Bind<Exception, IApiExceptions>().To<ApiException>().InSingletonScope();

            kernel.Bind<GenericIdentity>().To<BasicAuthenticationIdentity>();
            kernel.Bind<AuthorizationFilterAttribute>().To<GenericAuthenticationFilter>();
            kernel.Bind<GenericAuthenticationFilter>().To<ApiAuthenticationFilter>();

            kernel.Bind<ITokenServices>().To<RepositoryTokenServices>();
            kernel.Bind<IErrorLogger>().To<RepositotyErrorLogger>();
            kernel.Bind(typeof(GenericUserManagementRepositoty<>));
            kernel.Bind<IDisposable>().To<UnitOfWork>();
            //kernel.Bind<RestClient>().To<RepositoryClient>();
        }        
    }

    public class NinjectHttpDependencyResolver : IDependencyResolver, IDependencyScope
    {
        private readonly IKernel _kernel;
        public NinjectHttpDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //Do nothing
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avisos.Models.Abstract
{
    public interface IAvisoRepository 
    {
        Aviso Get(int id);
        IQueryable<Aviso> GetAll();
        Aviso Add(Aviso aviso);
        Aviso Update(Aviso aviso);
        void Delete(int id);
        IEnumerable<Aviso> GetByType(AvisoType type);
    }


    public interface IDependencyResolver : System.Web.Http.Dependencies.IDependencyScope, IDisposable
    {
        System.Web.Http.Dependencies.IDependencyScope BeginScope();
    }
    

    public class NinjectScope : System.Web.Http.Dependencies.IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }

    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace WangYc.Controllers
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {

        private IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {

            if (container == null)
            {
                throw new ArgumentException("container");
            }
            this.container = container; // ObjectFactory.Container;
        }

        public object GetService(Type serviceType)
        {

            try
            {
                return container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            try
            {
                return container.GetAllInstances<object>();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }


        public IDependencyScope BeginScope()
        {

            var child = container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}

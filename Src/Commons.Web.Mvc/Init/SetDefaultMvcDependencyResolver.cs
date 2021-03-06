using System.Collections;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using BoC.EventAggregator;
using BoC.Tasks;
using BoC.Web.Mvc.IoC;
using IDependencyResolver = BoC.InversionOfControl.IDependencyResolver;

namespace BoC.Web.Mvc.Init
{
    public class SetDefaultMvcDependencyResolver : IBootstrapperTask
    {
        private BoCDependencyResolver _boCDependencyResolver;

        public SetDefaultMvcDependencyResolver(IDependencyResolver dependencyResolver, IEventAggregator eventAggregator)
        {
            _boCDependencyResolver = new BoCDependencyResolver(dependencyResolver, eventAggregator);
        }

        public void Execute()
        {
            DependencyResolver.SetResolver(_boCDependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = _boCDependencyResolver;
        }
    }
}
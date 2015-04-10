using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _Kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _Kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _Kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            _Kernel.Bind<IDiscountHelper>()
                .To<DefaultDiscountHelper>()
                .WithConstructorArgument("discountSize", 50M);
            _Kernel.Bind<IDiscountHelper>()
                .To<FlexibleDiscountHelper>()
                .WhenInjectedInto<LinqValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return _Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Kernel.GetAll(serviceType);
        }
    }
}
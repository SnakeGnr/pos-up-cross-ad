using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Threading.Tasks;

namespace trab_xamarin.ViewModel.Base
{
   public  class ViewModelLocator
    {
        IContainer _container;
        ContainerBuilder _containerBuilder;

        static readonly ViewModelLocator _instace = new ViewModelLocator();

        public static ViewModelLocator Instace
        {
            get { return _instace; }
        }

        public ViewModelLocator()
        {
            _containerBuilder = new ContainerBuilder();
        }

        public T Resolve<T>() => _container.Resolve<T>();

        public object Resolve (Type type)
        {
            return _container.Resolve(type);
        }

        public void Register<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void Register<T> () where T: class
        {
            _containerBuilder.RegisterType<T>();
        }

        public void Build()
        {
            if (_container == null)
                _container = _containerBuilder.Build();
        }
    } 
}

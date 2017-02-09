using Ninject;
using System;
using System.Reflection;
using TestApi1.Repository.Impl.Persons;
using TestApi1.Repository.Persons;

namespace TestApi1.App_Start
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        }

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IPersonRepository>()
             .To<PersonRepository>();
        }
    }
}
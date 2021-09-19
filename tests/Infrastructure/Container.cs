using Microsoft.Extensions.DependencyInjection;

namespace tests.Infrastructure
{
    public class Container
    {
        private readonly ServiceCollection _serviceCollection = new();

        public void Register<T1, T2>()
            where T1 : class
            where T2 : class, T1 => _serviceCollection.AddTransient<T1, T2>();

        public T Resolve<T>() => _serviceCollection.BuildServiceProvider().GetService<T>();
    }
}
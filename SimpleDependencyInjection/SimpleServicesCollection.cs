using SimpleDependencyInjection.LifeTimes;

namespace SimpleDependencyInjection
{
    public class SimpleServicesCollection
    {
        private Dictionary<Type, ISimpleServiceLifeTime> servicesCollection = new();

        public void AddSingleton<TService, TImplementation>()
        {
            AddServicesCollection(new SimpleServiceSingleton(this, typeof(TService), typeof(TImplementation)));
        }

        public void AddTransient<TService, TImplementation>()
        {
            AddServicesCollection(new SimpleServiceTransient(this, typeof(TService), typeof(TImplementation)));
        }

        private void AddServicesCollection(ISimpleServiceLifeTime simpleServiceLifeTime)
        {
            if (!servicesCollection.ContainsKey(simpleServiceLifeTime.ServiceType))
                servicesCollection.Add(simpleServiceLifeTime.ServiceType, simpleServiceLifeTime);
            else
                servicesCollection[simpleServiceLifeTime.ServiceType] = simpleServiceLifeTime;
        }

        public TService GetService<TService>() => (TService)GetService(typeof(TService));

        public object GetService(Type type)
        {
            if (!servicesCollection.TryGetValue(type, out var service))
                return null;

            return service.GetInstance();
        }
    }
}

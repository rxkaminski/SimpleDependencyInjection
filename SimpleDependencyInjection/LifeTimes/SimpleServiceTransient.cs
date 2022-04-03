namespace SimpleDependencyInjection.LifeTimes
{
    public sealed class SimpleServiceTransient : SimpleServiceLifeTime
    {
        public SimpleServiceTransient(SimpleServicesCollection simpleServicesCollection, Type serviceType, Type implementationType) :
            base(simpleServicesCollection, serviceType, implementationType)
        {
        }
    }
}

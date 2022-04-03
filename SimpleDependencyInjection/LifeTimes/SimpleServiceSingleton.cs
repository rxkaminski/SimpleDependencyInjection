namespace SimpleDependencyInjection.LifeTimes
{
    public sealed class SimpleServiceSingleton : SimpleServiceLifeTime
    {
        public SimpleServiceSingleton(SimpleServicesCollection simpleServicesCollection, Type serviceType, Type implementationType) : 
            base(simpleServicesCollection, serviceType, implementationType)
        {
        }

        public object Instance { get; private set; }

        public override object GetInstance()
        {
            return Instance ??= base.GetInstance();
        }
    }
}

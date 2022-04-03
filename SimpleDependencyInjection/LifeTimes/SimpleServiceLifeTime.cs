namespace SimpleDependencyInjection.LifeTimes
{
    public abstract class SimpleServiceLifeTime : ISimpleServiceLifeTime
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }

        private SimpleServicesCollection simpleServicesCollection;

        public SimpleServiceLifeTime(SimpleServicesCollection simpleServicesCollection, Type serviceType, Type implementationType)
        {
            this.simpleServicesCollection = simpleServicesCollection;
            this.ServiceType = serviceType;
            this.ImplementationType = implementationType;
        }

        public virtual object GetInstance()
        {
            return Activator.CreateInstance(ImplementationType, GetInstancesForParametersFromFirstConstructior());
        }

        private object[] GetInstancesForParametersFromFirstConstructior()
        {
            return ImplementationType
                        .GetConstructors()
                        .First()
                        .GetParameters()
                        .Select(p => simpleServicesCollection.GetService(p.ParameterType))
                        .ToArray();
        }
    }
}

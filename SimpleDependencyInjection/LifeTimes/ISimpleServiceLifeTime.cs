namespace SimpleDependencyInjection.LifeTimes
{
    public interface ISimpleServiceLifeTime
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public object GetInstance();
    }
}

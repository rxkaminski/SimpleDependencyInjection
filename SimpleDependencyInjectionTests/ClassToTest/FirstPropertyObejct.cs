namespace SimpleDependencyInjectionTests.ClassToTest
{
    public interface IFirstPropertyObejct
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }

    public class FirstPropertyObejct : IFirstPropertyObejct
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = nameof(FirstPropertyObejct);

        public override string ToString()
            => $"{Name} \t{Guid}";
    }
}

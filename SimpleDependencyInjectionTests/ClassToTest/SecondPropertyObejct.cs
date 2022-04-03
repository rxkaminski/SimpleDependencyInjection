namespace SimpleDependencyInjectionTests.ClassToTest
{
    public interface ISecondPropertyObejct
    {
        public Guid Guid { get; set; } 

        public string Name { get; set; }
    }
    public class SecondPropertyObejct : ISecondPropertyObejct
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = nameof(SecondPropertyObejct);

        public override string ToString()
            => $"{Name} \t{Guid}";
    }
}

namespace SimpleDependencyInjectionTests.ClassToTest
{
    public interface ISecondTestObject
    {
        public IFirstPropertyObejct FirstPropertyObejct { get; set; }
        public ISecondPropertyObejct SecondPropertyObejct { get; set; }

        public string Name { get; }
        public Guid Guid{ get; set; }
    }

    public class SecondTestObject : ISecondTestObject
    {
        public IFirstPropertyObejct FirstPropertyObejct { get; set; }
        public ISecondPropertyObejct SecondPropertyObejct { get; set; }
        public string Name { get => nameof(SecondTestObject); }
        public Guid Guid { get; set; } = Guid.NewGuid();

        
        public SecondTestObject(IFirstPropertyObejct firstPropertyObejct, ISecondPropertyObejct secondPropertyObejct)
        {
            FirstPropertyObejct = firstPropertyObejct;
            SecondPropertyObejct = secondPropertyObejct;
        }

        public override string ToString()
            => $"{Name} \t{Guid} \t{FirstPropertyObejct} \t{SecondPropertyObejct}";
    }
}

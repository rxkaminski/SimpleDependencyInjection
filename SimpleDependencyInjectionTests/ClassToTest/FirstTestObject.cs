namespace SimpleDependencyInjectionTests.ClassToTest
{
    public interface IFirstTestObject
    {
        public IFirstPropertyObejct FirstPropertyObejct { get; set; }
        public ISecondPropertyObejct SecondPropertyObejct { get; set; }

        public string Name { get; }
        public Guid Guid { get; set; }
    }

    public class FirstTestObject : IFirstTestObject
    {
        public IFirstPropertyObejct FirstPropertyObejct { get; set; }
        public ISecondPropertyObejct SecondPropertyObejct { get; set; }
        public string Name { get => nameof(FirstTestObject); }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public FirstTestObject(IFirstPropertyObejct firstPropertyObejct, ISecondPropertyObejct secondPropertyObejct)
        {
            FirstPropertyObejct = firstPropertyObejct;
            SecondPropertyObejct = secondPropertyObejct;
        }

        public override string ToString()
            => $"{Name} \t{Guid} \t{FirstPropertyObejct} \t{SecondPropertyObejct}";
    }

    public class AlternativeFirstTestObject : IFirstTestObject
    {
        public IFirstPropertyObejct FirstPropertyObejct { get; set; }
        public ISecondPropertyObejct SecondPropertyObejct { get; set; }
        public string Name { get => nameof(FirstTestObject); }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public AlternativeFirstTestObject(IFirstPropertyObejct firstPropertyObejct, ISecondPropertyObejct secondPropertyObejct)
        {
            FirstPropertyObejct = firstPropertyObejct;
            SecondPropertyObejct = secondPropertyObejct;
        }

        public override string ToString()
            => $"{Name} \t{Guid} \t{FirstPropertyObejct} \t{SecondPropertyObejct}";
    }
}

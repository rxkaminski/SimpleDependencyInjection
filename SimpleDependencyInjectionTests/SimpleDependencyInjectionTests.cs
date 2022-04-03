using SimpleDependencyInjection;
using SimpleDependencyInjectionTests.ClassToTest;
using Xunit;

namespace SimpleDependencyInjectionTests
{
    public class SimpleDependencyInjectionTest
    {
        [Fact]
        public void CheckSingletonSingletonSingleton()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddSingleton<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddSingleton<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesSimple.AddSingleton<ISecondPropertyObejct, SecondPropertyObejct>();


            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();
            var first2 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.Equal(first1.Guid, first2.Guid);
            Assert.Equal(first1.FirstPropertyObejct.Guid, first2.FirstPropertyObejct.Guid);
            Assert.Equal(first1.SecondPropertyObejct.Guid, first2.SecondPropertyObejct.Guid);
        }

        [Fact]
        public void CheckTransientSingletonSingleton()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddSingleton<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesSimple.AddSingleton<ISecondPropertyObejct, SecondPropertyObejct>();


            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();
            var first2 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.NotEqual(first1.Guid, first2.Guid);
            Assert.Equal(first1.FirstPropertyObejct.Guid, first2.FirstPropertyObejct.Guid);
            Assert.Equal(first1.SecondPropertyObejct.Guid, first2.SecondPropertyObejct.Guid);
        }

        [Fact]
        public void CheckTransientTransientSingleton()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddTransient<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesSimple.AddSingleton<ISecondPropertyObejct, SecondPropertyObejct>();


            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();
            var first2 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.NotEqual(first1.Guid, first2.Guid);
            Assert.NotEqual(first1.FirstPropertyObejct.Guid, first2.FirstPropertyObejct.Guid);
            Assert.Equal(first1.SecondPropertyObejct.Guid, first2.SecondPropertyObejct.Guid);
        }

        [Fact]
        public void CheckTransientTransientTransient()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddTransient<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesSimple.AddTransient<ISecondPropertyObejct, SecondPropertyObejct>();


            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();
            var first2 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.NotEqual(first1.Guid, first2.Guid);
            Assert.NotEqual(first1.FirstPropertyObejct.Guid, first2.FirstPropertyObejct.Guid);
            Assert.NotEqual(first1.SecondPropertyObejct.Guid, first2.SecondPropertyObejct.Guid);
        }

        [Fact]
        public void CheckReturnNullIfDidntAddToCollection()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();

            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.Null(first1);
        }

        [Fact]
        public void CheckReturnLastAddedInctance()
        {
            //Arrange
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddTransient<IFirstTestObject, AlternativeFirstTestObject>();

            //Act
            var first1 = servicesSimple.GetService<IFirstTestObject>();

            //Assert
            Assert.False(first1 is FirstTestObject);
            Assert.True(first1 is AlternativeFirstTestObject);
        }
    }
}

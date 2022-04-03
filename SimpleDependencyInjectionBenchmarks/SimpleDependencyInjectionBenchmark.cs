using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using SimpleDependencyInjection;
using SimpleDependencyInjectionTests.ClassToTest;


namespace SimpleDependencyInjectionBenchmarks
{
    [MemoryDiagnoser]
    public class SimpleDependencyInjectionBenchmark
    {
        [Benchmark(Baseline = true)]
        public void SimpleDependencyInjection()
        {
            var servicesSimple = new SimpleServicesCollection();
            servicesSimple.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesSimple.AddTransient<ISecondTestObject, SecondTestObject>();
            servicesSimple.AddTransient<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesSimple.AddSingleton<ISecondPropertyObejct, SecondPropertyObejct>();

            var first1 = servicesSimple.GetService<IFirstTestObject>();
            var first2 = servicesSimple.GetService<IFirstTestObject>();
            var second1 = servicesSimple.GetService<ISecondTestObject>();
            var second2 = servicesSimple.GetService<ISecondTestObject>();


            //Console.WriteLine($"First1 {first1}");
            //Console.WriteLine($"First2 {first2}");
            //Console.WriteLine($"Second1 {second1}");
            //Console.WriteLine($"Second2 {second2}");
        }

        [Benchmark]
        public void DependencyInjectionMs()
        {
            var servicesMs = new ServiceCollection();
            servicesMs.AddTransient<IFirstTestObject, FirstTestObject>();
            servicesMs.AddTransient<ISecondTestObject, SecondTestObject>();
            servicesMs.AddTransient<IFirstPropertyObejct, FirstPropertyObejct>();
            servicesMs.AddSingleton<ISecondPropertyObejct, SecondPropertyObejct>();
            var buildMs = servicesMs.BuildServiceProvider();

            var first1 = buildMs.GetService<IFirstTestObject>();
            var first2 = buildMs.GetService<IFirstTestObject>();
            var second1 = buildMs.GetService<ISecondTestObject>();
            var second2 = buildMs.GetService<ISecondTestObject>();

            //Console.WriteLine($"First1 {first1}");
            //Console.WriteLine($"First2 {first2}");
            //Console.WriteLine($"Second1 {second1}");
            //Console.WriteLine($"Second2 {second2}");
        }
    }
}

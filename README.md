# SimpleDependencyInjection

Simple implementation of dependency injection collection


## Benchmark

|                    Method |      Mean |     Error |    StdDev |    Median |  Gen 0 |  Gen 1 | Allocated |
|-------------------------- |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
| SimpleDependencyInjection |  5.748 us | 0.1051 us | 0.1947 us |  5.655 us | 1.3809 |      - |      6 KB |
|     DependencyInjectionMs | 17.733 us | 0.9800 us | 2.8894 us | 18.222 us | 2.6245 | 1.3123 |     12 KB |

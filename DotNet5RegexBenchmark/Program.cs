using BenchmarkDotNet.Running;

namespace DotNet5RegexBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<RegexBenchmarks>();
        }
    }
}

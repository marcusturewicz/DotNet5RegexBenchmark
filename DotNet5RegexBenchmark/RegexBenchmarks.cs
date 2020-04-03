using System.IO;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotNet5RegexBenchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [MemoryDiagnoser]
    public class RegexBenchmarks
    {
        private string _data;

        [GlobalSetup]
        public void Setup()
        {
            _data = File.ReadAllText("input-text.txt");
        }

        [Benchmark]
        public int Email() => Regex.Matches(_data, @"[\w\.+-]+@[\w\.-]+\.[\w\.-]+", RegexOptions.Compiled).Count;

        [Benchmark]
        public int URI() => Regex.Matches(_data, @"[\w]+://[^/\s?#]+[^\s?#]+(?:\?[^\s#]*)?(?:#[^\s]*)?", RegexOptions.Compiled).Count;

        [Benchmark]
        public int IP() => Regex.Matches(_data, @"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9])", RegexOptions.Compiled).Count;
    }
}

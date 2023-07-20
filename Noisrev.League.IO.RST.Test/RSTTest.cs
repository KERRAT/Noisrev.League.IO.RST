using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Text;

namespace Noisrev.League.IO.RST.Test
{
    [SimpleJob(RuntimeMoniker.Net461)]
    [MemoryDiagnoser]
    [RPlotExporter]
    [RankColumn]
    public class RSTReadTest
    {
        private readonly string en_us = Path.Combine("Resources", "main_ru_ru.stringtable");
        private RSTFile InputRSTFile;

        [GlobalSetup]
        public void Setup()
        {
            InputRSTFile = new RSTFile(File.OpenRead(en_us), false);
        }

        [Benchmark]
        public void Open()
        {
            InputRSTFile = new RSTFile(File.OpenRead(en_us), false);
        }
    }

    [SimpleJob(RuntimeMoniker.Net461)]
    [MemoryDiagnoser]
    [RPlotExporter]
    [RankColumn]
    public class RSTWriteTest
    {
        public readonly string en_us = Path.Combine("Resources", "main_ru_ru.stringtable");
        public readonly string output = Path.Combine("Resources", "main_ru_ru_output.stringtable");
        public RSTFile InputRSTFile;

        [GlobalSetup]
        public void Setup()
        {
            InputRSTFile = new RSTFile(File.OpenRead(en_us), false);
        }

        [Benchmark]
        public void Write()
        {
            InputRSTFile.Write(File.Create(output), false);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //BenchmarkRunner.Run<RSTReadTest>();
            BenchmarkRunner.Run<RSTWriteTest>();
        }
    }
}

using BenchmarkDotNet.Running;
using BenchmarkForForeach;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<LoopBenchmarks>();
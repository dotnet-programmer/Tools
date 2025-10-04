using BenchmarkDotNet.Attributes;

namespace BenchmarkForForeach;

public class LoopBenchmarks
{
	private readonly string _text = new('a', 1000);

	[Benchmark]
	public void ForLoop()
	{
		for (int i = 0; i < _text.Length; i++)
		{
			char c = _text[i];
		}
	}

	[Benchmark]
	public void ForeachLoop()
	{
		foreach (var c in _text)
		{
		}
	}
}
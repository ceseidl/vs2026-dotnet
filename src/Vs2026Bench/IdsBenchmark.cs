using System.Text;
using BenchmarkDotNet.Attributes;

namespace Vs2026Bench;

[MemoryDiagnoser]
public class IdsBenchmark
{
    private readonly int[] _ids =
        Enumerable.Range(1, 1000).ToArray();

    // Ponto quente tipico: concatenacao dentro de loop.
    [Benchmark(Baseline = true)]
    public string Concatenar()
    {
        var resultado = "";
        foreach (var id in _ids)
            resultado += id + ",";
        return resultado;
    }

    [Benchmark]
    public string ComStringBuilder()
    {
        var sb = new StringBuilder();
        foreach (var id in _ids)
            sb.Append(id).Append(',');
        return sb.ToString();
    }

    [Benchmark]
    public string ComJoin() => string.Join(',', _ids);
}

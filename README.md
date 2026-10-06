English | [Português](README.pt-BR.md)

# vs2026-dotnet

> **Quick start**

```bash
dotnet build
dotnet run --project src/Vs2026Demo --no-build
```

Needs only the .NET 10 SDK. Details in [How to run](#how-to-run).

Companion code for the article "Visual Studio 2026 para .NET: o que muda no dia a dia" (pt-BR). It shows, in a few small files, what changes in daily work with Visual Studio 2026, .NET 10 and C# 14: the `.slnx` solution format, a pinned SDK, shared build settings, the C# 14 features and a BenchmarkDotNet benchmark of the kind the Copilot Profiler Agent works with.

## What it is

- **Vs2026Demo**: console app with the C# 14 features: the `field` keyword, extension members, null-conditional assignment, `nameof` with an unbound generic type and lambda parameter modifiers without types.
- **Vs2026Bench**: BenchmarkDotNet benchmark comparing three ways of building a string from 1000 ids (concatenation in a loop, `StringBuilder`, `string.Join`).
- `vs2026-dotnet.slnx`: the solution in the XML `.slnx` format (default of `dotnet new sln` in .NET 10).
- `global.json` and `Directory.Build.props`: pinned SDK and settings shared by all projects.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2026 is optional: everything runs from the CLI and opens in the IDE through the `.slnx`.

## How to run

```bash
dotnet build
dotnet run --project src/Vs2026Demo --no-build
```

Expected output:

```
Nome: 'Ana'
Apelido: Aninha
Total: 246.40
Pagos: 2
Vazio: Pedido { Id = 0, Valor = 0, Pago = False, Cliente =  }
Dictionary
42
```

Benchmark (takes a few minutes; use Release):

```bash
dotnet run -c Release --project src/Vs2026Bench -- --job short
```

Numbers depend on the machine. On a laptop with .NET 10.0.12 the loop concatenation took about 600 us and 3.7 MB per call, against about 11 us and 16 KB for `StringBuilder`.

## Structure

```
vs2026-dotnet.slnx
global.json
Directory.Build.props
src/
  Vs2026Demo/    Pedido.cs, PedidoExtensions.cs, Program.cs
  Vs2026Bench/   IdsBenchmark.cs, Program.cs
```

Identifiers are kept in Portuguese to match the article.

## License

[MIT](LICENSE). Author: Carlos Eduardo Seidl.

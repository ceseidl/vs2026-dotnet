[English](README.md) | Português

# vs2026-dotnet

> **Início rápido**

```bash
dotnet build
dotnet run --project src/Vs2026Demo --no-build
```

Precisa só do SDK do .NET 10. Detalhes em [Como rodar](#como-rodar).

Código do artigo "Visual Studio 2026 para quem escreve .NET". Mostra, em poucos arquivos, o que muda no dia a dia com o Visual Studio 2026, o .NET 10 e o C# 14: o formato de solução `.slnx`, o SDK fixado, as configurações compartilhadas de build, os recursos do C# 14 e um benchmark BenchmarkDotNet do tipo com que o Copilot Profiler Agent trabalha.

## O que é

- **Vs2026Demo**: aplicação console com os recursos do C# 14: a palavra-chave `field`, membros de extensão, atribuição com null-condicional, `nameof` com tipo genérico aberto e modificadores em parâmetros de lambda sem tipos.
- **Vs2026Bench**: benchmark BenchmarkDotNet que compara três formas de montar uma string com 1000 ids (concatenação em loop, `StringBuilder`, `string.Join`).
- `vs2026-dotnet.slnx`: a solução no formato XML `.slnx` (padrão do `dotnet new sln` no .NET 10).
- `global.json` e `Directory.Build.props`: SDK fixado e configurações comuns a todos os projetos.

## Pré-requisitos

- [SDK do .NET 10](https://dotnet.microsoft.com/download)
- O Visual Studio 2026 é opcional: tudo roda pela CLI e abre na IDE pelo `.slnx`.

## Como rodar

```bash
dotnet build
dotnet run --project src/Vs2026Demo --no-build
```

Saída esperada:

```
Nome: 'Ana'
Apelido: Aninha
Total: 246.40
Pagos: 2
Vazio: Pedido { Id = 0, Valor = 0, Pago = False, Cliente =  }
Dictionary
42
```

Benchmark (leva alguns minutos; use Release):

```bash
dotnet run -c Release --project src/Vs2026Bench -- --job short
```

Os números dependem da máquina. Em um notebook com .NET 10.0.12, a concatenação em loop levou cerca de 600 us e 3,7 MB por chamada, contra cerca de 11 us e 16 KB do `StringBuilder`.

## Estrutura

```
vs2026-dotnet.slnx
global.json
Directory.Build.props
src/
  Vs2026Demo/    Pedido.cs, PedidoExtensions.cs, Program.cs
  Vs2026Bench/   IdsBenchmark.cs, Program.cs
```

Os identificadores ficam em português para combinar com o artigo.

## Licença

[MIT](LICENSE). Autor: Carlos Eduardo Seidl.

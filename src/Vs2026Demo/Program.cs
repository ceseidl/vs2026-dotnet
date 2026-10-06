using System.Globalization;
using Vs2026Demo;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var ana = new Cliente { Nome = "  Ana  " };
Console.WriteLine($"Nome: '{ana.Nome}'");

// C# 14: atribuicao com null-condicional.
Cliente? semCliente = null;
semCliente?.Apelido = "ignorado";
ana?.Apelido = "Aninha";
Console.WriteLine($"Apelido: {ana?.Apelido}");

List<Pedido> pedidos =
[
    new(1, 120.50m, true, ana),
    new(2, 80.00m, false, ana),
    new(3, 45.90m, true),
];

Console.WriteLine($"Total: {pedidos.Total}");
Console.WriteLine($"Pagos: {pedidos.Pagos().Count()}");
Console.WriteLine($"Vazio: {Pedido.Vazio}");

// C# 14: nameof com generico aberto.
Console.WriteLine(nameof(Dictionary<,>));

// C# 14: modificadores em parametros de lambda sem tipos.
TryParse<int> tentar = (texto, out valor) =>
    int.TryParse(texto, out valor);
Console.WriteLine(tentar("42", out var n) ? n : -1);

delegate bool TryParse<T>(string texto, out T valor);

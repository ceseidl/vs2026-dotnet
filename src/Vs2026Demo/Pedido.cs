namespace Vs2026Demo;

public class Cliente
{
    // C# 14: 'field' dispensa o campo de apoio manual.
    public string Nome
    {
        get;
        set => field = value?.Trim()
            ?? throw new ArgumentNullException(nameof(value));
    } = "";

    public string? Apelido { get; set; }
}

public record Pedido(
    int Id, decimal Valor, bool Pago, Cliente? Cliente = null);

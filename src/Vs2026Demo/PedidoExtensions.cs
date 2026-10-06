namespace Vs2026Demo;

public static class PedidoExtensions
{
    // C# 14: membros de extensao (propriedades e estaticos).
    extension(IEnumerable<Pedido> pedidos)
    {
        public decimal Total => pedidos.Sum(p => p.Valor);

        public IEnumerable<Pedido> Pagos() =>
            pedidos.Where(p => p.Pago);
    }

    extension(Pedido)
    {
        public static Pedido Vazio => new(0, 0m, false);
    }
}

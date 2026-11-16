using Esfiharia;
using Xunit;

namespace Esfiharia.Tests;

public class ConfirmacaoPedidoTests
{
    [Fact]
    public void ConfirmaPedidoComPix()
    {
        ConfirmacaoPedido pedido = new ConfirmacaoPedido();

        bool resultado = pedido.Confirmar(26.00m, "pix");

        Assert.True(resultado);
        Assert.True(pedido.Confirmado);
    }

    [Fact]
    public void RejeitaPagamentoComBoleto()
    {
        ConfirmacaoPedido pedido = new ConfirmacaoPedido();

        bool resultado = pedido.Confirmar(26.00m, "boleto");

        Assert.False(resultado);
        Assert.False(pedido.Confirmado);
    }

    [Fact]
    public void RejeitaPedidoVazio()
    {
        ConfirmacaoPedido pedido = new ConfirmacaoPedido();

        bool resultado = pedido.Confirmar(0.00m, "pix");

        Assert.False(resultado);
        Assert.False(pedido.Confirmado);
    }
}
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

    [Fact]
public void NaoAdicionaEsfihaDepoisDeConfirmar()
{
    var pedido = new Pedido();
    pedido.Adicionar(1, 4);
    pedido.Adicionar(2, 1);

    Assert.True(pedido.Confirmar("pix"));

    Assert.Throws<InvalidOperationException>(() => pedido.Adicionar(1, 1));
    Assert.Equal(26.00m, pedido.CalcularSubtotal());
}
}
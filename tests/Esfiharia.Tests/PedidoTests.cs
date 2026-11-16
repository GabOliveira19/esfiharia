using Esfiharia;
using Xunit;

namespace Esfiharia.Tests;

public class PedidoTests
{
    [Fact]
    public void AdicionarEsfihasDiferentesSomaPrecoVezesQuantidade()
    {
        var pedido = new Pedido();
        pedido.Adicionar(1, 4);
        pedido.Adicionar(2, 1);

        Assert.Equal(26.00m, pedido.CalcularSubtotal());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AdicionarQuantidadeZeroOuNegativaLancaExcecaoEPreservaSubtotal(int quantidade)
    {
        var pedido = new Pedido();
        pedido.Adicionar(1, 2); // subtotal = 10,00

        Assert.Throws<ArgumentOutOfRangeException>(() => pedido.Adicionar(1, quantidade));
        Assert.Equal(10.00m, pedido.CalcularSubtotal());
    }
}

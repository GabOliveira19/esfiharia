using Esfiharia;
using Xunit;

namespace Esfiharia.Tests;

public class CardapioTests
{
    [Fact]
    public void BuscarCodigo1RetornaCarneComPrecoCinco()
    {
        Esfiha esfiha = Cardapio.Buscar(1);

        Assert.Equal("Carne", esfiha.Sabor);
        Assert.Equal(5.00m, esfiha.Preco);
    }

    [Fact]
    public void BuscarCodigo2RetornaQueijoComPrecoSeis()
    {
        Esfiha esfiha = Cardapio.Buscar(2);

        Assert.Equal("Queijo", esfiha.Sabor);
        Assert.Equal(6.00m, esfiha.Preco);
    }

    [Fact]
    public void BuscarCodigo3RetornaFrangoComPrecoSete()
    {
        Esfiha esfiha = Cardapio.Buscar(3);

        Assert.Equal("Frango", esfiha.Sabor);
        Assert.Equal(7.00m, esfiha.Preco);
    }

    [Fact]
    public void BuscarCodigoInvalidoLancaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Cardapio.Buscar(99));
    }
}
namespace Esfiharia;

public class Pedido
{
    private decimal subtotal;

    public void Adicionar(int codigoEsfiha, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "Informe uma quantidade maior que zero.");

        Esfiha esfiha = Cardapio.Buscar(codigoEsfiha);
        subtotal += esfiha.Preco * quantidade;
    }

    public decimal CalcularSubtotal()
    {
        return subtotal;
    }
}

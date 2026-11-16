namespace Esfiharia;

public class Pedido
{
    private decimal subtotal;
    private readonly ConfirmacaoPedido confirmacao = new ConfirmacaoPedido();

    public void Adicionar(int codigoEsfiha, int quantidade)
    {
        if (confirmacao.Confirmado)
        {
            throw new InvalidOperationException("O pedido já foi confirmado.");
        }

        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantidade), "Informe uma quantidade maior que zero.");
        }

        Esfiha esfiha = Cardapio.Buscar(codigoEsfiha);
        subtotal += esfiha.Preco * quantidade;
    }

    public decimal CalcularSubtotal()
    {
        return subtotal;
    }

    public bool Confirmar(string pagamento)
    {
        return confirmacao.Confirmar(subtotal, pagamento);
    }
}
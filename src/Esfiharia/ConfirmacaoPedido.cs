namespace Esfiharia;

public class ConfirmacaoPedido
{
    public bool Confirmado { get; private set; }

    public bool Confirmar(decimal subtotal, string pagamento)
    {
        if (Confirmado)
        {
            return false;
        }

        if (subtotal <= 0)
        {
            return false;
        }

        if (pagamento == "pix" || pagamento == "cartao" || pagamento == "dinheiro")
        {
            Confirmado = true;
            return true;
        }

        return false;
    }
}
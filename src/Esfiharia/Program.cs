using Esfiharia;

ConfirmacaoPedido pedido = new ConfirmacaoPedido();

Console.WriteLine("Pedido de R$ 26,00");
Console.WriteLine("Digite o pagamento: pix, cartao ou dinheiro");
string pagamento = Console.ReadLine() ?? "";

if (pedido.Confirmar(26.00m, pagamento))
{
    Console.WriteLine("Pedido confirmado!");
}
else
{
    Console.WriteLine("Pedido recusado.");
}
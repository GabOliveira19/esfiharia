using System.Globalization;
using Esfiharia;

var brasil = CultureInfo.GetCultureInfo("pt-BR");
var pedido = new Pedido();

MostrarSecao("ESFIHARIA - CARDÁPIO");
Console.WriteLine("1 - Carne");
Console.WriteLine("2 - Queijo");
Console.WriteLine("3 - Frango");

while (true)
{
    Console.Write("Digite o código da esfiha (0 para terminar): ");
    var entrada = Console.ReadLine();

    if (entrada == null)
    {
        return;
    }

    if (!int.TryParse(entrada, out int codigo) || codigo < 0 || codigo > 3)
    {
        Console.WriteLine("Código inválido.");
        continue;
    }

    if (codigo == 0)
    {
        break;
    }

    var esfihaEscolhida = Cardapio.Buscar(codigo);
    Console.WriteLine($"{esfihaEscolhida.Sabor} por {esfihaEscolhida.Preco.ToString("C2", brasil)}");

    Console.Write("Digite a quantidade: ");

    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
    {
        Console.WriteLine("Digite uma quantidade maior que zero.");
        continue;
    }

    pedido.Adicionar(codigo, quantidade);
}

var subtotal = pedido.CalcularSubtotal();

if (subtotal <= 0)
{
    Console.WriteLine("Pedido recusado. Adicione pelo menos uma esfiha.");
    return;
}

MostrarSecao("ENTREGA OU RETIRADA");
Console.WriteLine("Subtotal: " + subtotal.ToString("C2", brasil));
Console.WriteLine("1 - Entrega");
Console.WriteLine("2 - Retirada");
Console.Write("Digite sua opção: ");

var opcao = Console.ReadLine();
string modalidade;

if (opcao == "1")
{
    modalidade = "Entrega";
}
else if (opcao == "2")
{
    modalidade = "Retirada";
}
else
{
    Console.WriteLine("Modalidade inválida.");
    return;
}

decimal taxa;

try
{
    taxa = CalculadoraTaxaEntrega.Calcular(subtotal, modalidade);
}
catch (ArgumentException ex)
{
    Console.WriteLine("Erro na taxa: " + ex.Message);
    return;
}

var total = subtotal + taxa;

MostrarSecao("PAGAMENTO");
Console.Write("Digite o pagamento (pix, cartao ou dinheiro): ");
var pagamento = Console.ReadLine() ?? "";

if (!pedido.Confirmar(pagamento))
{
    Console.WriteLine("Pedido recusado. Forma de pagamento inválida.");
    return;
}

MostrarSecao("RESUMO DO PEDIDO");
Console.WriteLine("Subtotal:   " + subtotal.ToString("C2", brasil));
Console.WriteLine("Modalidade: " + modalidade);
Console.WriteLine("Taxa:       " + taxa.ToString("C2", brasil));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("TOTAL:      " + total.ToString("C2", brasil));
Console.ResetColor();

Console.WriteLine("Pedido confirmado!");

static void MostrarSecao(string titulo)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("================================");
    Console.WriteLine("  " + titulo);
    Console.WriteLine("================================");
    Console.ResetColor();
}

Console.WriteLine("=== SISTEMA DE TAXA DE ESFIRRARIA ===");

Console.Write("\nDigite o valor do pedido: R$ ");

if (!decimal.TryParse(Console.ReadLine(), out decimal subtotal))
{
    Console.WriteLine("Valor inválido!");
    return;
}

Console.WriteLine("\nEscolha a modalidade:");
Console.WriteLine("1 - Entrega");
Console.WriteLine("2 - Retirada");

Console.Write("\nDigite sua opção: ");
string opcao = Console.ReadLine()!;

string modalidade = opcao == "1" ? "Entrega" :
                    opcao == "2" ? "Retirada" : "";

try
{
    decimal taxa = CalculadoraTaxaEntrega.Calcular(
        subtotal, modalidade
    );

    decimal total = subtotal + taxa;

    Console.WriteLine("\n===== RESUMO DO PEDIDO =====");
    Console.WriteLine($"Valor do pedido: R$ {subtotal:F2}");
    Console.WriteLine($"Modalidade: {modalidade}");
    Console.WriteLine($"Taxa de entrega: R$ {taxa:F2}");
    Console.WriteLine("----------------------------");
    Console.WriteLine($"TOTAL: R$ {total:F2}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\nErro: {ex.Message}");
}

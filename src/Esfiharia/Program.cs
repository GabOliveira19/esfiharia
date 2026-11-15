using System.Globalization;
using Esfiharia;

var brasil = CultureInfo.GetCultureInfo("pt-BR");

// Consulta ao cardápio
Esfiha esfiha = Cardapio.Buscar(1);
Console.WriteLine($"Código 1: {esfiha.Sabor} por {esfiha.Preco.ToString("C2", brasil)}");

// Subtotal do pedido
var pedido = new Pedido();
pedido.Adicionar(1, 4);
pedido.Adicionar(2, 1);
Console.WriteLine("Subtotal: " + pedido.CalcularSubtotal().ToString("C2", brasil));
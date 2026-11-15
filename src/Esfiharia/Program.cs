using System.Globalization;
using Esfiharia;

var brasil = CultureInfo.GetCultureInfo("pt-BR");
Esfiha esfiha = Cardapio.Buscar(1);
Console.WriteLine($"Código 1: {esfiha.Sabor} por {esfiha.Preco.ToString("C2", brasil)}");
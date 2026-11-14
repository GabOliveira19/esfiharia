using Esfiharia;

var pedido = new Pedido();
pedido.Adicionar(1, 4);
pedido.Adicionar(2, 1);

var brasil = new System.Globalization.CultureInfo("pt-BR");
Console.WriteLine("Subtotal: " + pedido.CalcularSubtotal().ToString("C2", brasil));
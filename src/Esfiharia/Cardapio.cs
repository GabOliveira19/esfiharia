namespace Esfiharia;

public record Esfiha(string Sabor, decimal Preco);

public static class Cardapio
{
    public static Esfiha Buscar(int codigo)
    {
        return codigo switch
        {
            1 => new Esfiha("Carne", 5.00m),
            2 => new Esfiha("Queijo", 6.00m),
            3 => new Esfiha("Frango", 7.00m),
            _ => throw new ArgumentException("Código fora do cardápio.", nameof(codigo))
        };
    }
}

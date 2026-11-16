
public class CalculadoraTaxaEntrega
{
    private const decimal VALOR_MINIMO = 30.00m;
    private const decimal TAXA_ENTREGA = 6.00m;

    public static decimal Calcular(decimal subtotal, string modalidade)
    {
        if (subtotal < 0)
        {
            throw new ArgumentException(
                "O subtotal não pode ser negativo."
            );
        }

        if (modalidade == "Retirada")
        {
            return 0m;
        }

        if (modalidade == "Entrega")
        {
            return subtotal < VALOR_MINIMO
                ? TAXA_ENTREGA
                : 0m;
        }

        throw new ArgumentException(
            "Modalidade inválida."
        );
    }
}
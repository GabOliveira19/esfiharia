## Funcionalidade 03 – Calcular taxa de entrega ou retirada

### História do usuário

Como cliente, quero saber a taxa antes de confirmar meu pedido para escolher entre entrega e retirada.

### Objetivo

Aplicar a taxa de entrega conforme a modalidade escolhida e o subtotal do pedido.

### Usuário

Cliente.

### Fluxo esperado

1. O cliente informa o subtotal do pedido.
2. O cliente escolhe entre entrega ou retirada.
3. O sistema consulta a modalidade e o subtotal.
4. O sistema calcula e apresenta a taxa correspondente.
5. O cliente visualiza o valor total antes de confirmar o pedido.

### Critérios de aceitação

- Uma entrega de um pedido de R$ 26,00 gera uma taxa de R$ 6,00.
- Uma entrega de um pedido de exatamente R$ 30,00 tem taxa zero.
- Uma retirada tem taxa zero, inclusive para pedidos abaixo de R$ 30,00.

### Regras de negócio

- Cobrar R$ 6,00 pela entrega se o subtotal for menor que R$ 30,00.
- Isentar a taxa de entrega para pedidos com subtotal igual ou superior a R$ 30,00.
- Isentar a taxa em qualquer retirada.

### Arquivos responsáveis

- `CalculadoraTaxaEntrega.cs`: implementação das regras de cálculo da taxa.
- `ConfirmarPedido.cs`: interação com o cliente, apresentação dos valores e confirmação do pedido.
- `Program.cs`: inicialização da funcionalidade.

### Status

Funcionalidade em desenvolvimento.

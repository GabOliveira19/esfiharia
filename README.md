# Esfiharia

Trabalho prático da disciplina de **Gestão da Qualidade de Software** do curso de Ciência da Computação da **UNIFENAS**. O projeto é uma aplicação de console em **C# com .NET 8** que simula pedidos de uma esfiharia. Os testes automatizados foram escritos com **xUnit**.

## Integrantes e contribuições

| Integrante | Contribuição |
|---|---|
| Leonardo | Consulta de sabor e preço pelo código da esfiha. |
| Pedro | Product Owner (PO). Organização do backlog no Trello, inclusão de esfihas e cálculo do subtotal. |
| Jonas | Cálculo da taxa de entrega ou retirada. |
| Gabriel Oliveira | Confirmação do pedido, integração das funcionalidades no console e testes da confirmação. |

## Como o sistema funciona

O atendente informa o código e a quantidade das esfihas. Ao digitar um código válido, o programa mostra o sabor e o preço unitário. O código `0` encerra a inclusão de itens. Em seguida, o atendente escolhe entrega ou retirada e informa o pagamento. Quando o pedido é confirmado, o console mostra o subtotal, a modalidade, a taxa e o total.

### Cardápio

| Código | Sabor | Preço unitário |
|---|---|---:|
| `1` | Carne | R$ 5,00 |
| `2` | Queijo | R$ 6,00 |
| `3` | Frango | R$ 7,00 |

### Regras de negócio

- O cardápio informa o sabor e o preço pelo código. Um código inexistente é rejeitado.
- A quantidade precisa ser maior que zero. O subtotal é a soma do preço unitário multiplicado pela quantidade de cada item.
- A **retirada é gratuita**.
- A **entrega custa R$ 6,00** quando o subtotal é menor que **R$ 30,00**. A partir de **R$ 30,00**, a entrega é gratuita.
- O pedido precisa ter pelo menos uma esfiha e um pagamento válido. Digite `pix`, `cartao` ou `dinheiro`. Os pagamentos são simulados.
- Depois que o pedido é confirmado, novas inclusões de esfihas são bloqueadas.

## Como executar

Instale o **SDK do .NET 8**. Baixe ou clone o repositório e abra no VS Code a pasta que contém `Esfiharia.sln`.

No terminal dessa pasta, execute:

```powershell
dotnet run --project src/Esfiharia/Esfiharia.csproj
```

### Exemplo de pedido

Digite cada opção e pressione **Enter**.

| Ordem | Valor | Significado |
|---|---|---|
| 1 | `1` | Escolher carne |
| 2 | `4` | Adicionar quatro unidades |
| 3 | `2` | Escolher queijo |
| 4 | `1` | Adicionar uma unidade |
| 5 | `0` | Encerrar a inclusão de itens |
| 6 | `1` | Escolher entrega |
| 7 | `pix` | Informar a forma de pagamento |

O resultado esperado é **subtotal de R$ 26,00**, **taxa de R$ 6,00**, **total de R$ 32,00** e a mensagem **Pedido confirmado!**

## Testes automatizados

O projeto `tests/Esfiharia.Tests` usa **xUnit** para verificar o comportamento das regras da aplicação. Para rodar todos os testes, execute na pasta que contém `Esfiharia.sln`:

```powershell
dotnet test Esfiharia.sln
```

Na validação da `release/1.0.0`, os **11 testes passaram**, com **0 falhas**.

Entre os cenários automatizados na confirmação estão:

| Cenário | Resultado esperado |
|---|---|
| Confirmar um pedido de R$ 26,00 com Pix | O pedido é confirmado. |
| Tentar confirmar com boleto | O pagamento é rejeitado e o pedido continua em aberto. |
| Tentar confirmar um pedido vazio | O pedido é recusado. |
| Tentar adicionar outra esfiha depois de confirmar | A inclusão é bloqueada e o subtotal continua em R$ 26,00. |

## Estrutura do projeto

| Caminho | Conteúdo |
|---|---|
| `src/Esfiharia/Program.cs` | Fluxo interativo do pedido e apresentação do resumo no console. |
| `src/Esfiharia/` | Classes do cardápio, pedido, confirmação e cálculo da taxa. |
| `tests/Esfiharia.Tests/` | Projeto com os testes automatizados em xUnit. |
| `Esfiharia.sln` | Solução que reúne a aplicação e o projeto de testes. |
| `global.json` | Configuração da versão do SDK usada no projeto. |

## Organização do trabalho

Os requisitos foram organizados em cards no **Trello**. Cada integrante trabalhou na sua funcionalidade, fez commits com a própria conta e usou pull requests para integrar as mudanças no GitHub.

| Branch | Finalidade |
|---|---|
| `feature/*` | Desenvolvimento das funcionalidades e melhorias. |
| `develop` | Integração das contribuições do grupo. |
| `release/1.0.0` | Preparação e validação da versão 1.0.0. |
| `main` | Publicação da versão estável para entrega. |
# Aula 5

## Expressões Lambda

`Expressão lambda` é o nome de um tipo de expressão utilizada no C# para criar funções anônimas. As `funções anônimas` possuem esse nome porque é um bloco de código que define uma função sem explicitar o nome dela.

Basicamente, é uma função definida e executada ao mesmo tempo, em tempo de execução.

&nbsp;

A estrutura básica de uma expressão lambda é:

> (parâmetros) => corpo

&nbsp;

Na aula 2, fizemos um exercício que consistia em filtrar e remover strings com tamanho maior que 5 caracteres em uma lista.

```csharp
public static class Aula5
{
    public static void MapAula5Endpoints(this WebApplication app)
    {
        
    }

    
}
```

&nbsp;

Poderíamos substituir a função estática `FiltrarStringsLongas` por uma expressão lambda, conforme visto abaixo:

```csharp

```

&nbsp;

Nesse caso, podemos remover a função estática `FiltrarStringsLongas` do código e utilizar somente a expressão lambda.

> Obs: Se formos reutilizar o método FiltrarStringsLongas, ou qualquer outro método, o melhor é manter ele ao invés de usar expressões lambda. Se for necessário refatorar ele por algum motivo, modificamos somente uma vez ao invés de sair procurando todas as expressões lambda.

&nbsp;

Também podemos transformar uma expressão lambda em função, desde que ela tenha um único parâmetro e retorne um valor.

```csharp

```

&nbsp;

O corpo das expressões lambda também podem receber mais de uma linha. Em geral utiliza-se duas ou três linhas no máximo.

```csharp

```

&nbsp;

### Parâmetros

Quanto a passagem de parâmetros, as expressões lambda podem receber 0, 1 ou mais parâmetros.

Quando recebe 0 parâmetros, utilizamos parênteses vazios

```csharp

```

&nbsp;

Quando possui 1 único parâmetro, podemos usar ou não os parênteses.

```csharp

```

&nbsp;

Quando possui 2 ou mais parâmetros, os parênteses são obrigatórios.

```csharp

```

&nbsp;

### Uso mais comum

Nos exemplos acima trouxemos algumas situações mais ou menos comuns que podem ser utilizadas as expressões lambda. Uma delas em particular acaba sendo o principal uso destas expressões, que é a aplicação direta das expressões lambda em listas e outras estruturas.



```csharp

```

&nbsp;

Observem que podemos receber uma determinada lista e realizar um ou mais processamentos nela `de forma encadeada`. No exemplo abaixo

```csharp

```

pegamos a lista original com valores de 0 a 20 e filtramos os pares (`Where`). Da lista resultante aplicamos um cálculo (`Select`) para obter o quadrado dos elementos da lista anterior. Feito isso, ordenamos essa lista de forma decrescente (`OrderByDescending`), filtramos novamente os que possuem valor acima de 100 (`TakeWhile`) e realizamos a soma deles, retornando por fim a soma dos números da lista.

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
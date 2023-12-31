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
         app.MapGet("/aula_5", () =>
        {
            List<string> strings = new List<string>() { "thread", "codigo", "tranquilo", "programa", "nao", "algoritmo", "curta" };

            var listaDeStrings = FiltrarStringsLongas(strings);

            
            return "Transforma DEV";
        });
    }

    static List<string> FiltrarStringsLongas(List<string> strings)
    {
        List<string> resultado = new List<string>();
        foreach (string str in strings)
        {
            if (str.Length > 5)
            {
                resultado.Add(str);
            }
        }

        return resultado;
    }

    
}
```

&nbsp;

Poderíamos substituir a função estática `FiltrarStringsLongas` por uma expressão lambda, conforme visto abaixo:

```csharp

 List<string> stringsLongas = strings.Where((str) => str.Length > 5).ToList();

```

&nbsp;

Nesse caso, podemos remover a função estática `FiltrarStringsLongas` do código e utilizar somente a expressão lambda.

> Obs: Se formos reutilizar o método FiltrarStringsLongas, ou qualquer outro método, o melhor é manter ele ao invés de usar expressões lambda. Se for necessário refatorar ele por algum motivo, modificamos somente uma vez ao invés de sair procurando todas as expressões lambda.

&nbsp;

Também podemos transformar uma expressão lambda em função.

```csharp
Func<int, int> calcularQuadrado = x => x * x;
Console.WriteLine(calcularQuadrado(5));

// Podemos adicionar em classes também
//Teste2 t = new Teste2();
//Console.WriteLine(t.calcularQuadrado(7));
//Console.WriteLine(Teste2.calcularQuadrado2(7));

// Podemos adicionar em classes também
public class Teste2
{
    static Func<int, int> calcularQuadrado = x => x * x;
    Func<int, int> calcularQuadrado2 = x => x * x;
}
```

&nbsp;

O corpo das expressões lambda também podem receber mais de uma linha. Em geral utiliza-se duas ou três linhas no máximo.

```csharp

Console.Clear();
List<int> inteiros = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var quadradoPares = (List<int> inteiros) =>
{
    var pares = inteiros.Where(x => x % 2 == 0).ToList();
    var quadrados = pares.Select(x => x * x).ToList();
    return quadrados;
};


Console.WriteLine(string.Join(", ", quadradoPares(inteiros)));
Console.WriteLine(string.Join(", ", quadradoPares));

```

&nbsp;

### Parâmetros

Quanto a passagem de parâmetros, as expressões lambda podem receber 0, 1 ou mais parâmetros.

Quando recebe 0 parâmetros, utilizamos parênteses vazios

```csharp
Action line = () => Console.WriteLine("Expressão lambda sem nenhum parâmetro.");
line();
```

&nbsp;

Quando possui 1 único parâmetro, podemos usar ou não os parênteses.

```csharp
Func<int, int> cubo = x => x * x * x;
Func<int, int> quadratica = (x) => x * x * x * x;
Console.WriteLine(cubo(2));
Console.WriteLine(quadratica(2));
```

&nbsp;

Quando possui 2 ou mais parâmetros, os parênteses são obrigatórios.

```csharp
Func<int, int, bool> testarIgualdade = (x, y) => x == y;
Console.WriteLine(testarIgualdade(2, 3));
Console.WriteLine(testarIgualdade(2, 2));
```

&nbsp;

### Uso mais comum

Nos exemplos acima trouxemos algumas situações mais ou menos comuns que podem ser utilizadas as expressões lambda. Uma delas em particular acaba sendo o principal uso destas expressões, que é a aplicação direta das expressões lambda em listas e outras estruturas.

```csharp
var quadradoPares = (List<int> inteiros) =>
{
    var pares = inteiros.Where(x => x % 2 == 0).ToList();
    var quadrados = pares.Select(x => x * x).ToList();
    return quadrados;
};
```

&nbsp;

Observem que podemos receber uma determinada lista e realizar um ou mais processamentos nela `de forma encadeada`. No exemplo abaixo

```csharp
// Construção com encadeamento
var resultado = lista.Where(x => x % 2 != 0)
                     .Select(x => x * x * x)
                     .OrderByDescending(x => x)
                     .TakeWhile(x => x > 79)
                     .Sum();
Console.WriteLine(resultado);

// Construção para debug facilitado
var resultado2 = lista.Where(x => x % 2 != 0).ToList();
var resultado3 = resultado2.Select(x => x * x * x).ToList();
var resultado4 = resultado3.OrderByDescending(x => x)
                     .TakeWhile(x => x > 79);
var resultado5 = resultado4.Sum();

Console.WriteLine(resultado5);
```

pegamos a lista original com valores de 0 a 35 e filtramos os impares (`Where`). Da lista resultante aplicamos um cálculo (`Select`) para obter o cubo dos elementos da lista anterior. Feito isso, ordenamos essa lista de forma decrescente (`OrderByDescending`), filtramos novamente os que possuem valor acima de 79 (`TakeWhile`) e realizamos a soma deles, retornando por fim a soma dos números da lista.

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
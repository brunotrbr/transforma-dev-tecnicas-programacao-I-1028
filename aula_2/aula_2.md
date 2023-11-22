# Aula 2

&nbsp;

# O que são Collections?

Antes de explicar o que são Collections, é necessário definir o que são os tipos genéricos (`Generics`).

&nbsp;

De acordo com a Microsoft, `Generics` introduz o conceito de parâmetros tipados ao .NET, o que torna possível modelar classes e métodos que postergam a definição de um ou mais tipos até a declaração e instanciação do código.

A definição parece linda, mas e na prática? Bom, é possível perceber a semelhança entre as duas listas que vamos criar, `listaUm` e `listDois`, certo?

```csharp
// .. resto do código



// .. resto do código
```

Se vocês observarem, tanto na primeira quanto na segunda lista a adição de elementos se dá com o método `Add`, enquanto buscar o item da primeira posição é feito com o método `ElementAt`.

Por que isso ocorre?

Bem, através do conceito visto acima, de tipos genéricos, a lista padrão existente no C# é construída de uma forma que pode ser de inteiros, strings, booleanos, floats, classes, uma vez que só vai analizar o tipo durante o build do código.

Isso é importante porque facilita para nós programadores não ter que reescrever o código da lista para cada tipo diferente (uma para inteiros, outra para strings, e por ai vai...)

O C# já possui uma implementação padrão para diversas estruturas de dados básicas da computação, como dicionários, listas, pilhas, filas, entre outras. Todas elas estão disponíveis no _namespace Collections_.

### OBS: Namespaces

**Essa parte de namespaces é opcional, então vou deixar o código aqui mesmo**
Namespaces são utilizados para

1) organizar as classes em C#:

```csharp
System.Console.WriteLine("Teste")
```

onde `System` é o namespace e `Console` é a classe.

&nbsp;


2) para organizar o escopo dos nomes de classes em partes diferentes do código

```csharp
app.MapGet("/aula_2_generics", () =>
{
    // .. resto do código
    SampleNamespace.SampleClass.SampleMethod();
    OtherNamespace.SampleClass.SampleMethod();
    // .. resto do código
});

app.Run();


namespace SampleNamespace
{
    class SampleClass
    {
        public static void SampleMethod()
        {
            System.Console.WriteLine(
                "SampleMethod inside SampleNamespace");
        }
    }
}

namespace OtherNamespace
{
    class SampleClass
    {
        public static void SampleMethod()
        {
            System.Console.WriteLine(
                "SampleMethod inside OtherNamespace");
        }
    }
}
```

&nbsp;

## Arrays

**Arrays** são as estruturas de dados mais básicas da programação e, normalmente, a base para diversas outras estruturas.

São estruturas **indexadas** que permitem armazenar um **conjunto de valores do mesmo tipo**, ou seja, cada elemento do array é identificado por um índice e armazenam elementos de um mesmo tipo em sequência. O primeiro elemento do array é sempre no índice 0.

Arrays podem ser **unidimensionais** (simples, com uma dimensão), **bidimensionais** (com duas dimensões, como uma matriz) ou **multidimensionais** (com três ou mais dimensões).

Arrays podem ser inicializados de forma **explícita** ou **implícita**. A inicialização é dita **explícita** quando os **valores dos elementos do array são especificados na criação**. Caso seja criado um array com o **valor padrão do tipo dos elementos**, é dito que possui **inicialização implícita**.

```csharp



```

### Principais operações com arrays

#### Adicionar e remover elementos no array

Arrays possuem tamanho **fixo** e **imutável**. Para adicionar elementos em um array (ex: adicionar a 11º posição em um array com 10 elementos) é necessário recriar o array com um tamanho maior copiando o conteúdo antigo e adicionando no novo array. Ai depois adicionar os novos elementos.

```csharp



```

&nbsp;

Também podemos transformar o array em lista, adicionar o valor, e converter novamente para array. Por baixo do capô, a operação realizada é a mesma que fizemos manualmente antes, mas agora de uma forma simplificada.

```csharp



```

&nbsp;

## Arrays => Exercícios

1) Crie um array de strings com 5 elementos e preencha-o com os nomes de 5 capitais brasileiras. Em seguida, imprima o nome de cada capital na tela.
```csharp



```

2) Crie um array bidimensional de inteiros com 3 linhas e 4 colunas. Inicialize todos os elementos do array com o valor 9. Em seguida, imprima o valor de cada elemento do array na tela.

```csharp



```

## Collections: List

O primeiro tipo de collection que vamos ver acho que estão cansados de ouvir, ver ou até mesmo usar. Vamos começar pela lista. Ela é implementada em cima de arrays e possui as mesma funcionalidades básicas que ele, com algumas vantagens.

A implementação de lista abstrai operações manuais como aumentar a lista, remover elementos, etc, automatizando essas coisas pra gente. Agora temos funções que fazem esse trabalho pra gente.

E por ser implementado sobre arrays também podemos buscar elementos na lista usando os colchetes, conforme abaixo:

```csharp



```

É importante lembrar que o acesso a uma posição da lista pode retornar exceção caso a posição não tenha elementos:

```csharp



```

#### AddRange

O `AddRange` pode ser utilizado para extender listas. Já temos uma lista com um conteúdo, e queremos adicionar o conteúdo da segunda lista na primeira

```csharp



```

&nbsp;

### Remover / Remover na posição

#### Remove

Podemos remover a primeira ocorrência de um elemento utilizando o `Remove`. Ela retorna `true` caso consiga remover, e `false` caso não tenha o elemento

```csharp



```

#### RemoveAt

Podemos remover o elemento na posição X, desde que a lista tenha um elemento nessa posição

```csharp



```

&nbsp;

### Reverso

Ocasionalmente, podemos querer reverter uma lista, para exibir os elementos de trás para frente. Nesse caso, podemos usar o método `Reverse`

```csharp



```

&nbsp;

### Consultar elemento na posição

Podemos também consultar o elemento que está em uma determinada posição usando o `ElementAt`

```csharp



```

&nbsp;

### Primeiro / Primeiro ou default

Em alguns casos, podemos buscar listas de elementos de bancos de dados / apis, e queremos saber o primeiro valor para exibir

#### First
Nesse caso, usamos o `First` ou `FirstOrDefault`. A diferença entre os dois é que o `First` retorna o primeiro elemento ou exceção caso a lista esteja vazia

#### FirstOrDefault
O `FirstOrDefault` retorna o primeiro elemento ou o padrão do tipo (string vazia, 0 para inteiros, etc) caso não tenha elemento na lista

```csharp



```

&nbsp;

### Transformar em Conjunto

Em determinados momentos, podemos querer eliminar elementos repetidos da lista. Uma solução simples para essa operação é usar o método `ToHashSet`
```csharp



```

&nbsp;

### Todos atendem a condição

Podemos verificar também se todos os elementos atendem a uma condição específica

```csharp



```

&nbsp;

### Algum atende a condição

Podemos verificar também se pelo menos um dos elementos atendem a uma condição específica

```csharp



```

&nbsp;

O código fonte da lista está disponível aqui:
https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs,cf7f4095e4de7646

## Collections: List => Exercícios

3) Escreva uma função que receba uma lista de números aleatórios e retorne a soma de todos os números pares da lista.

```csharp



```

&nbsp;

4) Escreva uma função que receba uma lista de strings e retorne uma nova lista contendo somente strings que contenham mais que 5 caracteres.

```csharp



```

&nbsp;

5) Escreva uma função que receba uma lista de números e retorne uma nova lista contendo o qudrado de todos os números da lista original.

```csharp



```

&nbsp;

## Collections: Stack

A pilha é um tipo de estrutura de dados que segue o padrão LIFO (ou FILO) de processamento. LIFO vem do inglês _Last In First Out_, ou seja, o último a entrar é o primeiro a sair (enquanto FILO quer dizer _First In Last Out_, o primeiro a entrar é o último a sair).

Em geral, não deveríamos conhecer todos os elementos da pilha, somente o topo dela.

<img src=https://camo.githubusercontent.com/6f51c23f05ace48f16705df6090c794b259d4e38af98ff20ceffdd72301d7695/68747470733a2f2f73332d73612d656173742d312e616d617a6f6e6177732e636f6d2f6c6370692f31633962343633652d656165622d346463612d616634362d3632373838383936393665332e6a7067 width=150>

&nbsp;

É considerada a mais simples de todas as estruturas de dados, mas também é de extrema importância na computação. Um dos principais usos da pilha é a alocação de memória durante a execução de um programa. Outros usos comuns de pilhas são: 

- Desfazer/refazer operações de edição

- Navegação no histórico de visitação de páginas web

- Manipulação de expressões aritméticas (pré-fixada, pós-fixada, infixada)

O C# já possui uma classe para trabalhar com pilhas, que está dentro do _namespace Collections_, a `Stack`. Ela também funciona com tipos genéricos.

```csharp

```

As operações mais comuns de se realizar com pilhas são:

### Empilhar

Para adicionar elementos na pilha, utilizamos a operação `Push`.

```csharp



```

&nbsp;

### Desempilhar

Para remover o elemento do topo da pilha, utilizamos a operação `Pop`. Ela retorna o valor removido.

```csharp



```

Caso tente remover o elemento de uma pilha vazia, será levantada uma exceção.

```csharp



```

&nbsp;

### Topo

Podemos consultar o topo da pilha sem remover ele, utilizando o `Peek`.

```csharp



```

Existem diversas outras operações que podem ser realizadas com pilhas, da mesma forma que com listas.

`Any`, `All`, `ToHashSet`, `First`, etc.

Isso ocorre porque, em geral, as estruturas de dados implementam as mesmas interfaces, conforme podemos ver aqui:

https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs,cf7f4095e4de7646

&nbsp;

## Collections: Stack => Exercícios

6) Escreva uma função que receba uma string como entrada e retorne a string ao contrário. Utilize pilhas para resolver esse problema.
   
```csharp



```

7) Escreva uma função que receba uma expressão como entrada e verifique se a expressão está balanceada. Uma expressão está balanceada se para cada parênteses de abertura, deve ter um parênteses de fechamento correspondente Utilize pilhas para resolver esse problema.

```csharp



```

8) Escreva uma função que receba uma expressão posfixada como entrada e avalie a expressão. Uma expressão posfixada é uma expressão onde os operadores são escritos após os operandos. Utilize pilhas para resolver esse problema. Obs: Utilize somente números de 0 a 9, e somente uma expressão por vez.

Ex: 45+ -> Resultado deve ser 9

```csharp



```

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
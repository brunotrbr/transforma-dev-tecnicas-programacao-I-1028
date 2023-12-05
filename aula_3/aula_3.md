# Aula 3

## Collections: Queue

A fila é um tipo de estrutura de dados que segue o padrão FIFO. FIFO vem do inglês _First In First Out_, ou seja, o primeiro a entrar é o primeiro a sair.

Em geral, não deveríamos conhecer todos os elementos da fila, somente o próximo a sair dela.

<img src=https://camo.githubusercontent.com/6e487189b8798d3037648120ad58708fed727feea852cb2d9157d0301c7c4d86/68747470733a2f2f73332d73612d656173742d312e616d617a6f6e6177732e636f6d2f6c6370692f36396463376366342d653166322d346466372d626137312d3638613932323531306536352e706e67 width=150 style="background: white">

&nbsp;

É uma estrutura de dados relativamente simples com um uso bastante comum, mesmo que não estejamos treinados para enxergar ela na computação. Quer ver? Em que parte da computação vocês acham que usamos a fila? As filas podem ser utilizadas em:

- Sistemas de troca de mensagens (whatsapp, sms etc.)

- Impressão de documentos

- Programação concorrente
  
- Reservas em sistemas de compras online, entre diversos outros.

O C# já possui uma classe para trabalhar com pilhas, que está dentro do _namespace Collections_, a `Queue`. Ela também funciona com tipos genéricos.

```csharp

app.MapGet("/aula_3/queue", () =>
{
    Queue<string> fila = new Queue<string>();

    return "Aula 3 - Filas";
});

```

As operações mais comuns de se realizar com pilhas são:

### Enfileirar

Para adicionar elementos na fila, utilizamos a operação `Enqueue`.

```csharp

fila.Enqueue("Primeiro");
fila.Enqueue("Segundo");
fila.Enqueue("Terceiro");

foreach(var item in fila)
{
    Console.WriteLine(item);
}

Console.WriteLine();

```

&nbsp;

### Desenfileirar

Para remover primeiro elemento da fila, utilizamos a operação `Dequeue`. Ela retorna o valor removido.

```csharp

Console.WriteLine(fila.Dequeue());

Console.WriteLine();

foreach (var item in fila)
{
    Console.WriteLine(item);
}

```

Caso tente desenfileirar/consultar uma fila vazia, será levantada uma exceção.

```csharp

// fila.Dequeue();
// fila.Dequeue();
// fila.Dequeue(); // System.InvalidOperationException: 'Queue empty.'

```

&nbsp;

### Próximo da fila

Podemos consultar o próximo da fila sem remover ele, utilizamos o `Peek`.

```csharp

Console.WriteLine();
Console.WriteLine(fila.Peek());

```

&nbsp;

Existem diversas outras operações que podem ser realizadas com filas, da mesma forma que com listas e pilhas.

`Any`, `All`, `ToHashSet`, `First`, etc.

Isso ocorre porque, em geral, as estruturas de dados implementam as mesmas interfaces, conforme podemos ver aqui:

https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs,cf7f4095e4de7646

&nbsp;

## Collections: Queue => Exercícios

1) Escreva uma função que simule o jogo de batata quente. Nesse jogo, jogadores passam a batata quente por um círculo até ela explodir. O jogador que estiver com a batata quando explodir está fora do jogo. Utilize filas para resolver esse problema.

```csharp



```

2) Escreva uma função que verifique se uma determinada string é um palíndromo. Uma palavra é um palíndromo quando a leitura da direita para esquerda e da esquerda para direita são iguais. Utilize filas para resolver esse problema.

```csharp



```

3) Um escalonador de tarefas é um sistema que gerencia a execução de tarefas no computador. Utilize filas para implementar um escalonador de tarefas simples, que execute elas na ordem que forem submetidas. A função não precisa ter nenhum retorno. Obs: As tarefas executam por um período x de tempo.

```csharp

app.MapGet("/aula_3/ex_3", () =>
{
    //3) Um escalonador de tarefas é um sistema que gerencia a execução de tarefas no computador. Utilize filas para implementar um escalonador de tarefas simples, que execute elas na ordem que forem submetidas. A função não precisa ter nenhum retorno. Obs: As tarefas executam por um período x de tempo.
    int tempoDeExecucao = 4;
    Queue<int> tarefas = new Queue<int>();
    for(int i = 0; i < 7; i++)
    {
        tarefas.Enqueue(i);
    }

    int contador = 0;
    foreach(int i in tarefas)
    {
        while(contador < tempoDeExecucao)
        {
            Console.WriteLine($"Executando tarefa {i}");
            contador++;
        }
        Console.WriteLine();
        contador = 0;
    }
});

```

&nbsp;

## Collections: Dicionários

Um dicionário é uma coleção de chave-valor onde cada chave é única e mapeia para um único valor.

Eles são implementados usando _hash tables_, o que faz com que as operações de consulta, adição e remoção sejam rápidas.

Normalmente utilizamos dicionários quando queremos associar de forma eficiente valores e identificadores únicos. Eles são particularmente eficientes para:

- Consulta de operações, recuperando um valor de acordo com a chave correspondente.

- Mapeamento de dados, podendo mapear entre domínios diferentes. Por exemplo, traduzir palavras de um idioma para outro em um site.

- Gerenciamento de configurações, armazenando e gerenciando parâmetros e chaves em uma aplicação

O C# já possui uma classe para trabalhar com dicionários, que está dentro do _namespace Collections_, a `Dictionary`. Ela também funciona com tipos genéricos.


```csharp



```

As operações mais comuns de se realizar com dicionários são:

### Adicionar

Para adicionar um valor, utilizamos o método `Add`

```csharp



```

### Consultar valores

Para acessar valores no dicionário, podemos:

#### Acessar diretamente o conteúdo pelo nome da chave

```csharp



```

#### Tentar recuperar o valor de forma segura

Ou tentar recuperar o valor da chave utilizando o método `TryGetValue`.

```csharp



```

### Consultar chave

Podemos consultar se uma chave está no dicionário usando o método `ContainsKey`


```csharp



```

### Iterar sobre as chaves, obtendo os valores

Podemos iterar pelo dicionário utilizando o `foreach`:

```csharp



```

### Remover par chave-valor

Para remover um par chave-valor, utilizamos o método `Remove`

```csharp



```

### Exemplo/Exercício de uso de um dicionário

#### Contador de frequêcia de palavras em um texto

4) Sabem aqueles _buzzwords_ que as vezes nós vemos em sites e outros lugares? Podemos usar um dicionário para fazer isso, contando quantas ocorrências de cada palavra acontecem em um texto (no exemplo abaixo, vamos fazer a contagem com a música Carinho e Respeito, da Luiza Martins). Ordenar em ordem crescente e decrescente de quantidade.


```csharp
app.MapGet("/aula_3/ex_4", () => {
    var letra = "é que eu acabei de terminar e no meu perfil já tem textão juntei as palavras mais lindas que eu conhecia e finalizei bem clichê desejando tudo de bom vida que segue cada um na sua fica o carinho o respeito sem ressentimento amizade continua aprendi com os casal da internet como é que termina mas se eu fosse falar a verdade eu diria eu desejo que você se foda que pegue sapinho quando for beijar outra boca boca e quando você for coisar seu brinquedo não suba suba espalhe pro povo e cê viria piada na rua rua e eu desejo que você se foda e se levar alguém pra casa seu cachorro morda morda e que namore alguém que sua mãe não atura atura que você leve tanto tanto chifre que dê pra ver da lua mas fica o carinho e o respeito e vida que segue cada um na sua fica o carinho o respeito sem ressentimento amizade continua aprendi com os casal da internet como é que termina mas se eu fosse falar a verdade eu diria eu desejo que você se foda que pegue sapinho quando for beijar outra boca boca e quando você for coisar seu brinquedo não suba suba espalhe pro povo e cê viria piada na rua rua e eu desejo que você se foda e se levar alguém pra casa seu cachorro morda morda e que namore alguém que sua mãe não atura atura que você leve tanto tanto tanto tanto chifre que dê pra ver da lua mas fica o carinho e o respeito";

    return "Ver console";
});
```
&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
# Aula 7

Até o momento, os códigos que nós estávamos escrevendo sempre eram lidos e interpretados de forma sequencial, ou seja, para ele passar para a próxima linha precisava finalizar a linha anterior.

Agora vamos conhecer outras formas de programar, podendo até mesmo fazer uso de múltiplas CPUs. Conceitos como concorrência, paralelismo, threads, tasks, programação assíncrona serão usados daqui para frente, então é bom definir cada um deles antes de avançarmos para o código.

## Por que executar vários programas simultaneamente?

Para:

- Permitir que um usuário realize várias tarefas ao mesmo tempo
- Permitir que vários usuários acessem a máquina ao mesmo tempo
- Aproveitar melhor o tempo de ociosidade do processador (entradas e saídas, espera de eventos, etc);

&nbsp;

## Concorrência

Concorrência significa realizar mais de uma tarefa ao mesmo tempo.

Um exemplo comum para entendermos a concorrência é um servidor *web* que recebe múltiplas requisições ao mesmo tempo. Quando uma requisição (um *post*, um *get*, etc) chega no servidor, ele cria um novo processo ou uma nova *thread* para tratar aquela *request* enquanto continua aguardando novas conexões ou novas *requests*.

A concorrência é necessária sempre que precisamos que uma aplicação realize uma tarefa enquanto esta trabalhando em outra. Sendo assim, realizar tarefas de forma concorrente é o oposto a realizar tarefas de forma sequencial.

A concorrência **não é** a mesma coisa que multithreading.

&nbsp;

## Processos

Um processo é, basicamente, um programa em execução. Ele possui seu próprio espaço de memória, seus dados próprios, compete com os outros processos por tempo de CPU e possui ao menos uma thread.

&nbsp;

## Threads

As *threads* podem ser entendidas como processos mais leves, que possuem um espaço de memória compartilhado, cooperam entre si por tempo de CPU, compartilham também os dados e existem **dentro** de um processo.

&nbsp;

## Multithread

*Multithread* é uma forma de concorrência (mas não é a única) que usa mais de um *thread*, ou linhas de execução, para realizar mais de uma tarefa ao mesmo tempo.

Uma *thread* é uma sequência de instruções que pode ser executada independente de qualquer outro código.

Dessa forma, uma aplicação web inicia o processamento de um request em uma *thread* e a seguir, se outro *request* chegar enquanto ela esta processamento a primeira *request*, ela inicia o processamento em outra *thread*.

&nbsp;

### Bloqueio de thread: Javascript

Mas qual a importância de bloquear ou não bloquear a thread?

Caso vocês não saibam, o JavaScript permite escrever programas concorrentes também, mas com uma diferença fundamental: não há preempção. ou seja, o ambiente de execução do JavaScript executa cada tarefa até o final antes de executar outra tarefa.

Vamos ver um exemplo bem simples, disponivel nesse link aqui:

https://rodrigorgs.github.io/aulas/mata56/aula15-concorrencia

&nbsp;

## Paralelismo, ou Programação paralela

A programação paralela é usada para dividir uma tarefa em diversas partes e executar estas partes de forma simultânea.

Nós podemos, por exemplo, cantar e tomar banho ao mesmo tempo, e estas duas tarefas são realizadas em paralelo.

Além disso podemos ter dois tipos de paralelismo:

- Paralelismo de dados:  Onde temos uma coleção de valores e desejamos usar a mesma operação em cada um dos elementos da coleção.  Ex: Filtrar os elementos de um array
 
- Paralelismo de tarefas: Onde Temos um conjunto de tarefas independentes que desejamos realizar em paralelo. Ex: Enviar um email e um arquivo de texto ao usuário

&nbsp;

## Assincronismo ou Programação assíncrona

A programação assíncrona permite usar as *threads* em nossos processos de uma maneira mais eficiente. Ela é uma forma de concorrência que utiliza recursos como *future* ou *promises* e *callbacks* para evitar *threads* desnecessárias.

Um *future* ou *promise* é um tipo que representa alguma operação que será concluída no futuro. No .NET os tipos utilizados são `Task` e `Task<TResult>`, enquanto  APIs assíncronas mais antigas utilizam *callbacks* ou eventos em vez de *future*.

Como vimos antes, em caso de *multithread*, são abertas várias *threads* para realizar o processamento de requisições. Na programação assíncrona, a ideia é que uma operçaão seja iniciada e concluída algum tempo depois. Mas enquanto a operação está em adamento, a *thread* continua livre para realizar outros processamentos. Em outras palavras, a *thread* não fica bloqueada. Quando a operação for concluída, ela notifica o *future* (a *Task*) ou chama o *callback* de conclusão para que o aplicativo saiba que a operação foi concluída.

Atualmente o .NET suporta progração assíncrona de forma nativa, utilizado os operadores `async` e `await`, tornando ela quase tão simples de implementar quanto a programação síncrona. A palavra-chave `async` é adicionada a uma declaração de método, e seu objetivo principal é habilitar a palavra-chave `await` dentro desse método. Esse método assíncrono deve retornar uma `Task<T>` se retornar um valor, ou retornar uma `Task` se não retornar um valor.

&nbsp;

### Principais benefícios da programação assíncrona

A programação assíncrona tem dois benefícios principais:

- Para programas com interface gráfica de usuário, como os projetos Windows Forms ou WPF: Neste caso a programação assíncrona permite que o programa permaneça responsivo à entradas do usuário enquanto realiza os processamentos requisitados.
 
- Para programas do lado do servidor: a programação assíncrona permite escalabilidade. Um aplicativo de servidor pode escalar um pouco apenas usando o pool de threads, mas um aplicativo de servidor assíncrono geralmente pode escalar uma ordem de magnitude melhor do que isso.

&nbsp;

## Preempção

É a interrupção de uma tarefa antes de sua conclusão para dar lugar a outra tarefa.

&nbsp;

## Troca de contexto

É a troca de uma tarefa por outra tarefa.

&nbsp;


## Utilizando Programação Paralela

O .NET já possui uma biblioteca padrão para utilizar programação paralela, chamada de Task Parallel Library ou TPL. 

Vamos considerar o código abaixo:

```csharp
app.MapGet("/aula_7", () =>{
    Console.WriteLine("Aula 7");
    // Thread.Sleep(15000);

    Console.WriteLine("Aperte enter para inicar");
    Console.ReadLine();
    ProcessarLaco();
    Console.WriteLine("\n");

    Parallel.For(0, 11, i => Console.WriteLine($"[Síncrono] Valor := {i}, Thread := {Thread.CurrentThread.ManagedThreadId}"));
    Console.WriteLine("\n");

    
    return "Transforma DEV";
});

static void ProcessarLaco(){
    for(int i = 0; i <= 10; i++){
        Console.WriteLine($"[Parallel.For] Valor := {i} \t Thread := {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(500);
    }
}
```

A função processar laço vai percorrer os números de 0 a 10 e imprimir na tela seu valor e qual thread foi utilizada.

Quando usamos o `Parallel.For`, o número é processado por alguma thread (mas não sabemos qual, exatamente), e os números também são processados em paralelo, fora de ordem.

&nbsp;

Podemos utilizar também o `Parallel.ForEach`, que vai funcionar de forma semelhante ao ForEach sequencial.

```csharp
List<int> inteiros = new List<int>();
for(int i = 0; i <= 10; i++){
    inteiros.Add(i);
}
Parallel.ForEach(inteiros, i => Console.WriteLine($"[Parallel.ForEach] Valor := {i}, Thread := {Thread.CurrentThread.ManagedThreadId}"));
Console.WriteLine("\n");
```

&nbsp;

Geralmente devemos usar este recurso quando tivermos muitas operações que dependam de processamento de CPU (CPU-Bound) e que possam ser executadas de maneira paralela quando houver mais de uma ocorrência de item a ser processado.

Mas utilizar o Parallel.ForEach ou Parallel.For em operações/iterações simples que não utilizam muitos recursos não garantia de ser mais rápido do que um foreach padrão. 

Na verdade o custo de alocar threads da maneira que a classe Parallel faz pode causar uma "overhead" que pode deixar seu código mais lento. Então o "peso" da operação a ser executada dentro do foreach é o que vai ditar se compensa ou não a utilização da forma paralela.

Outro detalhe importante é que a programação paralela não é indicada para o ambiente web.

Como no ambiente web temos um ambiente de alta demanda onde cada thread tratar um request não seria recomendável ocupar várias threads para processar uma única requisição.

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/q194GuiGH5tsUbT68


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.


# Aula 8

## Programação assíncrona com Tasks

Uma *task* é um grupo de declarações relacionadas que são executadas nas *threads*.

Para entendermos melhor, observem a imagem abaixo, que mostra o fluxo de criação, inicialização, agendamento e execução de uma *task*, mostrando sua relação com *threads* e com os processadores.

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-8/tasks*threads*processador.jpg width=500>

Fonte: www.macoratti.net

- Após uma tarefa ser criada e iniciada, ela é adicionada em uma fila no *pool* de *threads*

- Em algum determinado momento, uma tarefa é executada em uma *thread* do *pool*

- Essa *thread* é atribuída e executada em um processador específico

&nbsp;

## Tasks

O .NET possui uma biblioteca pronta para trabalharmos com *tasks*, a `System.Threading.Tasks`. Utilizamos especificamente a classe `Task` para isso. No exemplo abaixo, vamos criar e executar automaticamente a tarefa.

```csharp

```

&nbsp;

Mas olhando o código acima, o que acontece primeiro? A execução da *task* ou o retorno? Não tem como saber, portanto podemos substituir o `return` por um `WriteLine`, para ver.

```csharp

```

&nbsp;

Com isso, podemos observar que o programa executa primeiro o *print* final, e por fim executa a *task*, mostrando assim seu comportamento assíncrono.

&nbsp;

E se quisermos fazer com que a *task* complete primeiro? Para isso, utilizamos o método de instância `Wait`, para que a *thread* seja bloqueada até que o código da *task* finalize. Após finalizar, o código segue em execução normalmente.

```csharp

```

&nbsp;

### Retornando valores

Podemos ainda fazer com que uma *task* retorne algum valor para quem chamou, utilizando a classe `Task<TResult>`.

```csharp

```

### Criando tasks, sem executar imediatamente

Podemos ainda criar as *tasks* mas não executá-las imediatamente. Para forçar a execução utilizamos o método de instância `Start`

```csharp

```


### Executando múltiplas tasks simultaneamente

Agora imaginem que queremos executar 2 ou mais *tasks* simultaneamente, e queremos que nosso programa só continue quando todas elas finalizarem. Ou que pelo menos uma finalize. Vamos chamar o método `Wait` manualmente para cada uma das *tasks*?

Não. Podemos usar os métodos da classe Task `WaitAll` e `WaitAny`. Com a execução desses métodos o código só prossegue após **todas** as *tasks* finalizarem e após **pelo menos uma** *task* finalizar, respectivamente.

```csharp

```

```csharp

```

## Programação assíncrona com async/await

Não vamos entrar em detalhes sobre como funciona a programação síncrona, pois praticamente todos os programas escritos por nós até o momento.

No caso da programação assíncrona, como vimos anteriomente, a *thread* fica livre para executar outros processos.

Para utilizar a programação assíncrona, adicionamos o modificador `async` antes do nome do método, e dentro do método o modificador `await` na chamada assíncrona. 

Observem o exemplo abaixo:

```csharp

```

O processo longo inicia o processamento. Como ele é assíncrono, faz seu processamento em uma *thread* separada e libera a *thread* principal para realizar outros processamentos. Com isso, o código continua a execução, inicia e finaliza o processo curto, e depois o processo longo finaliza o seu processamento.


### Retornando valores

A programação assíncrona com `async/await` pode retornar valores também. O retorno é do tipo `Task<TResult>`, da mesma forma que as *tasks* vistas anteriormente.

```csharp

```

&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/q194GuiGH5tsUbT68


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
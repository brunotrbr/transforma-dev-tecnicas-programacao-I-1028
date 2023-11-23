# Aula 1

## Definições

Horário de início da aula: 19:10
- Tempo de intervalo: 15 minutos 

Projeto final / Exercícios avaliativos: 
- Grupo x individual 
- Exercícios x Projeto 

Comunicação 
- discord x email x whatsapp 

&nbsp;

## Instalando e configurando o Visual Studio

Vídeo disponível em: https://youtu.be/MLxSzQgg7ic

Link para download do Visual Studio Community: https://visualstudio.microsoft.com/pt-br/downloads/

A primeira vez que você tentar entrar no Visual Studio, ele deve pedir para logar com uma conta da Microsoft ou ignorar o login.

Depois disso, provavelmente peça para configurar o tema do VS (escuro, claro, etc).

&nbsp;

## Instalando .NET CLI

Caso não vá utilizar o Visual Studio (por exemplo, em ambientes Linux), pode baixar o SDK do .NET nos links abaixo:


https://dotnet.microsoft.com/pt-br/download/dotnet/6.0, para a versão do .NET 6

https://dotnet.microsoft.com/pt-br/download/dotnet/8.0, para a versão do .NET 8 (atual LTS)

&nbsp;

## O que são e quais os tipos de projetos em .NET

### Windows e MAC
Na tela inicial do Visual Studio (usando o 2022), vai ter 4 opções a direita:

- Clonar um repositório
- Abrir um projeto ou solução
- Abrir uma pasta local
- Criar um projeto

&nbsp;

Vamos clicar em `Criar um projeto` e ele vai liberar modelos diferentes de projeto para selecionarmos. Como são muitos, não vamos explicar um a um. Mas as opções ali envolvem soluções somente para *backend*, *backend* + *frontend* usando a *stack* inteira da Microsoft (razor pages, ou blazor), *frontend* com Angular, com React.JS, e por ai vai.

Dos projetos que estão ali, vale a pena mencionar os seguintes:

- Aplicativo de Console (que utiliza o console do windows para interação com o programa).
  
- API Web do ASP.NET Core (o *backend* tradicional, sem interface do *frontend*, com controller de exemplo. Utiliza o swagger ou programas como Postman ou Insomnia para interagir com ele).

- ASP.NET Core Vazio (o *backend* sem interface do *frontend*, vazio, sem controller nem outros recursos básicos da API. Utiliza o swagger ou programas como Postman ou Insomnia para interagir com ele. É o que vamos criar).
 
- Biblioteca de Classe (uma projeto auxiliar, utilizado para criar soluções específicas e integrar no projeto principal. Por exemplo, um projeto para lidar com grafos, informações de data e hora, geolocalização, etc).

&nbsp;

Vamos clicar em `Criar um projeto` e clicar em "Próximo".

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-1/criar_projeto.png width=500>

Neste ponto, vamos criar um projeto do tipo api web. Vamos clicar em `ASP.NET Core Vazio` e clicar no botão "Próximo".

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-1/selecionar_tipo_projeto.png width=500>

Na próxima tela, inserimos o nome do projeto, o local onde o projeto será salvo e marcamos a opção `Colocar a solução e o projeto no mesmo diretório`, e clicamos em próximo.

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-1/nome_do_projeto.png width=500>

Eu tenho o .NET 8.0 instalado no meu computador atualmente, então no *dropdown* de `Estrutura` aparece somente esta opção. O .NET 8.0 é a versão mais atual com LTS (*long term support*), suporte de longo prazo para melhorias e correções de bugs.

OBS: QUando eu tirei o print, eu tinha as versões .NET 6 e .NET 7.

Vou selecionar ela e deixar desmarcada a opção `Não use instruções de nível superior` Podemos deixar marcado também a opção `Configurar para HTTPS`.

Por fim, vamos clicar em Criar, e assim finalizar a criação do nosso primeiro projeto.

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-1/estrutura_do_projeto.png width=500>

&nbsp;

O projeto criado possui somente quatro linhas, mapeando a rota `/` da api para retornar um `"Hello World"`  

```csharp 
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

Agora vamos rodar o programa pela primeira vez, e o que acontece? Caso tenha sido marcada a opção "Configurar para HTTPS" na etapa anterior, vai ser solicitada a autorização e instalação do certificado SSL.

Feita a instalação, deve ser aberto o browser apontando para um endereço local e uma porta específica(`https://localhost:xxxx`) com a mensagem "Hello World".

&nbsp;

### Linux ou terminal

Para criar o projeto usando o terminal do windows ou do linux, é necessário ter instalado o .NET SDK no computador, conforme orientado no item `Instalando .NET CLI`.

Para instalar, abra o terminal e digite o seguinte comando:

```
C:\caminho\do\projeto> dotnet new web --name NomeDoApp
```
ou

```
user@machine:caminho/do/projeto$ dotnet new web --name NomeDoApp 
```

&nbsp;

### Instruções de nível superior e ImplicitUsing

Reparem também que não tem nenhuma instrução `using` no início do programa, e nem o clássico `main`. Por que isso? 

A partir da versão .NET 6 a Microsoft simplificou o código inicial, omitindo algumas partes para escrevermos o programa de forma mais simples.

Isso aconteceu porque não selecionamos aquela opção `Não use instruções de nível superior`, e tem uma opção no projeto habilitando o `using` implícito.

Para vermos a diferença, vamos criar um novo projeto selecionando a opção `Não use instruções de nível superior.`

```csharp
namespace NomeDoApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
```

E agora, vamos desabilitar o `using` implícito, clicando 2 vezes no nome do projeto no menu da direita, e inserindo o valor *`disable`* na chave *`ImplicitUsings`*

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>disable</ImplicitUsings>
  </PropertyGroup>

</Project>
```

Feito isso, quando formos compilar e rodar o projeto, o Visual Studio deve dar erro e acusar a ausência de `using`.

O `ImplicitUsing` pode ficar habilitado ou desabilitado, isso costuma ser mais uma escolha pessoal para o projeto. Como vantagem, não poluímos o projeto com algumas bibliotecas padrões do .NET. Como desvantagem, perdemos a noção do que está sendo importado para aquele projeto.

As bibliotecas implícitas são:
- System;
- System.IO;
- System.Collections.Generic;
- System.Linq;
- System.Net.Http;
- System.Threading;
- System.Threading.Tasks;
- Microsoft.AspNetCore.Builder;


No linux ou no terminal, adicionamos uma flag extra no comando
```
C:\caminho\do\projeto> dotnet new web --name NomeDoApp --use-program-main
```
ou

```
user@machine:caminho/do/projeto$ dotnet new web --name NomeDoApp --use-program-main
```

&nbsp;

## Quais os arquivos importantes no projeto?

Quando criamos o projeto de **api web**, são criados: 

- o projeto em si: `WebApplication1`
  - Contém informações sobre o projeto: framework usado, usings, etc
- o arquivo principal: `Program.cs`
  - Contém o código em si
- o gerenciador de dependências: `Dependências`
  - Permite gerenciar projetos ou outras bibliotecas no projeto corrente
- o gerenciador de serviços conectados: `Connected Services`
  - Permite gerenciar os serviços conectados no projeto, como xx, yy
- a pasta de propriedades, com informações sobre o lançamento do projeto: `launchSettings.json`
  - Contém informações sobre a inicialização do projeto, como uso de http/https, porta SSL, abertura de browser ao rodar, etc
- os arquivos de configuração: `appsettings.json`
  - Permite gerenciar variáveis de ambiente, chaves de serviços, urls, etc 

&nbsp;

### appsettings.json

Conforme dito anteriormente, o `appsettings.json` serve para centralizarmos dados e coisas relacionadas à configuração do projeto, de APIs externas, etc.

Para demonstrar melhor o uso do `appsettings.json`, considerem o seguinte caso:

Vamos criar uma nova aplicação `api web`, que vai se comunicar com nossa API, e para isso precisamos do endereço (a URL) da API.

A forma ruim de fazer isso é escrever a URL direto no código. No código abaixo, por exemplo, vamos fazer duas requisições para a rota `/` da nossa API, e escrever no console o resultado:

```csharp
// .. restante do código

app.MapGet("/", () => {
    // Criação do cliente HTTP
    HttpClient client = new HttpClient();

    // Get Request
    HttpRequestMessage requestMessage = new HttpRequestMessage(){
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://localhost:7120/")
    };

    HttpResponseMessage response = client.Send(requestMessage);

    var text = response.Content.ReadAsStringAsync().Result;

    Console.WriteLine(text);

    // Get Request
    requestMessage = new HttpRequestMessage(){
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://localhost:7120/")
    };

    response = client.Send(requestMessage);

    text = response.Content.ReadAsStringAsync().Result;

    Console.WriteLine(text);

    return text;
});

// .. restante do código
```

&nbsp;

Essa forma funciona, mas é ruim porque se alterar a URL uma vez, vamos ter que sair alterando na mão em todos os locais.

E além disso, essa forma não consegue diferir se estamos rodando em um ambiente local, de desenvolvimento, homologação, produção, etc.

&nbsp;

A forma correta de fazer isso é através de variáveis de ambiente, utilizando o `appsettings.json`. Vamos adicionar no `appsettings.Development.json` a seguinte chave com o endereço da api.

appsettings.Development.json
```json
"WebApi": {
    "url": "http://localhost:7120"
  }
```

E vamos criar um novo chamado `appsettings.Production.json`, apontando para o ambiente de produção com a url usando HTTPS:

appsettings.Production.json
```json
"WebApi": {
    "url": "https://localhost:7120"
  }
```

Agora, vamos alterar o arquivo `Program.cs`, para buscar a url que adicionamos no `appsettings.json`.


```csharp
// .. restante do código

app.MapGet("/", () => {
    // Criação do cliente HTTP
    HttpClient client = new HttpClient();

    // Utilizar o GetValue<type>(string key)
    var apiUrl = builder.Configuration.GetValue<string>("WebApi:url");
    Console.WriteLine(apiUrl);

    // Usando a propriedade indice, sempre retorna uma string
    var apiUrl2 = builder.Configuration["WebApi:url"];
    Console.WriteLine(apiUrl2);

    // Get Request
    HttpRequestMessage requestMessage = new HttpRequestMessage(){
        Method = HttpMethod.Get,
        RequestUri = new Uri(apiUrl)
    };

    HttpResponseMessage response = client.Send(requestMessage);

    var text = response.Content.ReadAsStringAsync().Result;

    Console.WriteLine(text);

    // Get Request
    requestMessage = new HttpRequestMessage(){
        Method = HttpMethod.Get,
        RequestUri = new Uri(apiUrl)
    };

    response = client.Send(requestMessage);

    text = response.Content.ReadAsStringAsync().Result;

    Console.WriteLine(text);

    return text;
});

// .. restante do código
```

Para executar nossa aplicação, vamos usar a linha de comando, através do comando `dotnet run`, com parâmetros adicionais para definir se o ambiente usado será de desenvolvimento (`Development`) ou produção (`Production`).

Development
```
dotnet run -lp WebApplication2
```

Production
```
dotnet run -lp WebApplication2Production
```

Agora, ao rodar o projeto, podemos ver as variáveis que foram obtidas do arquivo appsettings.json e fazer as requisições para nossa api.

#### Importante:

O `appsettings.json` é utilizado nos projetos do atual .NET. O antigo .NET FRAMEWORK utilizava um arquivo chamado `app.config` (para aplicações desktop/locais) ou `web.config` (para aplicações web), cuja função era exatamente a mesma do appsettings. Contudo ao invés de escrever um JSON era usado XML, conforme exemplo abaixo:

```xml
<?xml version="1.0"?>
<configuration>
  <appSettings>
    <WebApi>
        <add key="url" value="http://localhost:7183" />
    </WebApi>
  </appSettings>
</configuration>

```


### launchSettings.json

O launchSettings.json é utilizado no computador local para definir perfis de execução dentro do Visual Studio ou pela linha de comando.

No exemplo acima, vimos como executar a api simulando o ambiente de desenvolvimento e o de produção através do comando dotnet run.

No Visual Studio, alteramos o perfil de execução na barra superior, conforme visto na imagem abaixo.

<img src=https://s3.amazonaws.com/ada.8c8d357b5e872bbacd45197626bd5759/c-sharp/tecnicas-de-programacao/aula-1/launchsettings.png width=500>


&nbsp;

# Caixa de sugestões

Tem alguma sugestão para melhorar o andamento das aulas? Por favor preencha o formulário abaixo.

https://forms.gle/Yg6pSQFaoSYtZ4nG8


Não deixe a sugestão de melhorias para depois! Compartilhe antes, que corrijo o mais rápido possível.
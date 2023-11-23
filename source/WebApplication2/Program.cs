var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.Run();

using ProjetoAulas;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Transforma DEV!");

app.MapAula2Endpoints();
app.Run();

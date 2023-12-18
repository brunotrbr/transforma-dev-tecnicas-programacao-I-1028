using ProjetoAulas;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Transforma DEV!");

app.MapAula2Endpoints();
app.MapAula3Endpoints();
app.MapAula4Endpoints();
app.MapAula5Endpoints();
app.MapAula6Endpoints();
app.MapAula7Endpoints();
app.MapAula8Endpoints();
app.Run();

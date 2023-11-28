namespace ProjetoAulas
{
    public static class Aula3
    {
        public static void MapAula3Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_3", () =>
            {
                return "Aula 3";
            });
        }
    }
}

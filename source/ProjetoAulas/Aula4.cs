using System.Collections;
using System.Xml.Linq;

namespace ProjetoAulas
{
    public static class Aula4
    {
        public static void MapAula4Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_4/", () =>
            {
                var teste = new MinhaClasse();
                teste[0] = new MinhaClasse();
                teste.Append("dois");
                teste.Append("tres");

                return teste[0];
            });
        }
    }
}

public class MinhaClasse<T> : IEnumerable
{
    List<T> minhaLista = new List<T>();

    public IEnumerator GetEnumerator()
    {
        foreach (T val in minhaLista)
        {
            yield return val;
        }
    }
}
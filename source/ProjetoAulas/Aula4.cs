using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoAulas
{
    public class Aula4
    {
        public static void MapAula4Endpoints(this WebApplication app)
        {

        }

        public class Teste : IEnumerable
        {

            Teste[] Itens = null;
            int IndiceLivre = 0;
            string Nome { get; set; }
            int Idade { get; set; }

            public Teste(int capacidade)
            {
                Itens = new Teste[capacidade];
            }

            public void Add(Teste t)
            {
                Itens[IndiceLivre] = t;
                IndiceLivre++;
            }

            public IEnumerator GetEnumerator()
            {
                foreach (object o in Itens)
                {
                    if (o == null)
                    {
                        break;
                    }
                    yield return o;
                }
            }
        }
    }
}

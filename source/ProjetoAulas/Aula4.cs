using System.Collections;

namespace ProjetoAulas
{
    public static class Aula4
    {
        public static void MapAula4Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_4", () => {
                Teste t = new Teste();
                t.Add(5);
                t.Add(8);
                t.Add(null);
                t.Add(12);
                t.Add(66);

                //for(int i = 0; i < t.Count(); i++)
                //{
                //    Console.WriteLine(t[i]); // N�o funciona porque o c�digo ainda n�o permite o acesso por �ndice
                //    Console.WriteLine(t.Itens); // Itens � privado na classe Teste
                //}

                foreach(int? item in t)
                {
                    Console.WriteLine($"valor: {item}");
                }

                return "Transforma DEV";
            });
        }
    }

    public class Teste : IEnumerable<int?>
    {
        private int?[] Itens = new int?[0];

        public void Add(int? item)
        {
            // A cada adi��o, redimensionamos o array
            Array.Resize(ref Itens, Itens.Length + 1);
            Itens[Itens.Length - 1] = item;
        }

        public IEnumerator<int?> GetEnumerator()
        {
            foreach(int? num in Itens)
            {
                if(num == null)
                {
                    yield break;
                }
                Console.WriteLine($"foreach do GetEnumerator. valor: {num}");
                yield return num;

                //[1, 3, 5, 7, 9]
                //// retornei o n�mero 1, e o pr�xima a retornar � o n�mero 3
                //// posterga a avalia��o dos n�meros at� que seja solicitado novamente.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
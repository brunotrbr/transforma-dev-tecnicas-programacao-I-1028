namespace ProjetoAulas
{
    public static class Aula5
    {
        public static void MapAula5Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_5", () =>
            {
                List<string> strings = new List<string>() { "thread", "codigo", "tranquilo", "programa", "nao", "algoritmo", "curta" };

                var listaDeStrings = FiltrarStringsLongas(strings);
                List<string> stringsLongas = strings.Where((str) => str.Length > 5).ToList();

                Func<int, int> calcularQuadrado = x => x * x;
                Console.WriteLine(calcularQuadrado(5));

                // Podemos adicionar em classes também
                //Teste2 t = new Teste2();
                //Console.WriteLine(t.calcularQuadrado(7));
                //Console.WriteLine(Teste2.calcularQuadrado2(7));

                Console.Clear();
                List<int> inteiros = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                var quadradoPares = (List<int> inteiros) =>
                {
                    var pares = inteiros.Where(x => x % 2 == 0).ToList();
                    var quadrados = pares.Select(x => x * x).ToList();
                    return quadrados;
                };


                Console.WriteLine(string.Join(", ", quadradoPares(inteiros)));
                Console.WriteLine(string.Join(", ", quadradoPares));

                Console.Clear();

                Action line = () => Console.WriteLine("Expressão lambda sem nenhum parâmetro.");
                line();

                Func<int, int> cubo = x => x * x * x;
                Func<int, int> quadratica = (x) => x * x * x * x;
                Console.WriteLine(cubo(2));
                Console.WriteLine(quadratica(2));


                Func<int, int, bool> testarIgualdade = (x, y) => x == y;
                Console.WriteLine(testarIgualdade(2, 3));
                Console.WriteLine(testarIgualdade(2, 2));

                Console.Clear();

                List<int> lista = new List<int>();
                for(int i = 0; i <= 35; i++)
                {
                    lista.Add(i);
                }

                // Construção com encadeamento
                var resultado = lista.Where(x => x % 2 != 0)
                                     .Select(x => x * x * x)
                                     .OrderByDescending(x => x)
                                     .TakeWhile(x => x > 79)
                                     .Sum();
                Console.WriteLine(resultado);

                // Construção para debug facilitado
                var resultado2 = lista.Where(x => x % 2 != 0).ToList();
                var resultado3 = resultado2.Select(x => x * x * x).ToList();
                var resultado4 = resultado3.OrderByDescending(x => x)
                                     .TakeWhile(x => x > 79);
                var resultado5 = resultado4.Sum();
                
                Console.WriteLine(resultado5);

                return "Transforma DEV";
            });
        }



        static List<string> FiltrarStringsLongas(List<string> strings)
        {
            List<string> resultado = new List<string>();
            foreach (string str in strings)
            {
                if (str.Length > 5)
                {
                    resultado.Add(str);
                }
            }

            return resultado;
        }
    }

    // Podemos adicionar em classes também
    public class Teste2
    {
        static Func<int, int> calcularQuadrado = x => x * x;
        Func<int, int> calcularQuadrado2 = x => x * x;
    }
}

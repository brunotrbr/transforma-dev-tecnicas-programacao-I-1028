namespace ProjetoAulas
{
    public static class Aula2
    {
        public static void MapAula2Endpoints(this WebApplication app)
        {
            app.MapGet("/aula_2/generics", () =>
            {
                List<int> listaUm = new List<int>();
                List<string> listaDois = new List<string>();

                listaUm.Add(1);
                listaDois.Add("2");

                Console.WriteLine(listaUm[0]);
                Console.WriteLine(listaDois.ElementAt(0));

                return "Aula 2";
            });

            app.MapGet("/aula_2/arrays", () =>
            {
                // Declaração implícita
                int[] numeros = new int[10];

                for (int i = 0; i < numeros.Length; i++)
                {
                    Console.WriteLine(numeros[i]);
                }
                Console.Clear();

                // Declaração explícita
                string[] nomes = new string[] { "Anderson", "Bruno", "João" };

                for(int i = 0; i < nomes.Length; i++)
                {
                    Console.WriteLine(nomes[i]);
                }

                //try
                //{
                //    Console.WriteLine(nomes[3]);
                //} catch(IndexOutOfRangeException e)
                //{
                //    Console.WriteLine("Acesso indevido.");
                //    Console.WriteLine(e.Message);
                //    Console.WriteLine(e.StackTrace);
                //}
                Console.Clear();

                // Array Bidimensional, ou Matriz
                // O índice da esquerda deve ser entendido com a linha
                // O indice da direita deve ser entendido como a coluna
                int[,] matriz = new int[10, 20];

                Console.WriteLine(matriz[0, 1]);

                matriz[0, 1] = 2;

                Console.WriteLine(matriz[0, 1]);

                Console.Clear();

                // Declaração de matriz irregular, cujos tamanhos podem ser diferentes
                // A segunda dimensão inicializa com valor null

                int[][] matrizIrregular = new int[3][];

                matrizIrregular[0] = new int[] { 1, 3, 5, 7, 9 };
                matrizIrregular[1] = new int[] { 2, 4, 6, 8 };
                matrizIrregular[2] = new int[] { 11, 22 };

                for(int i = 0; i < matrizIrregular.GetLength(0); i++) {
                    for (int j = 0; j < matrizIrregular[i].Length; j++)
                    {
                        Console.WriteLine($"{matrizIrregular[i][j]}");
                    }
                    Console.WriteLine();
                }
                Console.Clear();

                for(int i = 0; i < numeros.Length; i++)
                {
                    numeros[i] = i * 2;
                }

                for (int i = 0; i < numeros.Length; i++)
                {
                    Console.WriteLine($"numeros[{i}] = {numeros[i]}");
                }

                int[] novoArray = new int[20];

                for (int i = 0; i < numeros.Length; i++)
                {
                    novoArray[i] = numeros[i];
                }

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }

                novoArray[numeros.Length] = 20;

                Console.WriteLine();
                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }
                Console.Clear();

                Console.WriteLine();
                for (int i = 0; i < novoArray.Length; i++)
                {
                    novoArray[i] = i * 2;
                }

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }

                novoArray = novoArray.ToList().Append(22).ToArray();

                for (int i = 0; i < novoArray.Length; i++)
                {
                    Console.WriteLine($"novoArray[{i}] = {novoArray[i]}");
                }
            });

            app.MapGet("/aula_2/list", () =>
            {
                List<int> listaUm = new List<int>();
                List<string> listaDois = new List<string>();

                listaUm.Add(1);
                listaDois.Add("2");

                Console.WriteLine(listaUm[0]);
                Console.WriteLine(listaDois.ElementAt(0));
                Console.Clear();
                List<int> listaTres = new List<int>() { 10, 18, 25, 39, 45 };

                for(int i = 0; i < listaUm.Count; i++)
                {
                    Console.WriteLine(listaUm[i]);
                }

                for (int i = 0; i < listaTres.Count; i++)
                {
                    Console.WriteLine(listaTres[i]);
                }

                listaUm.AddRange(listaTres);

                Console.WriteLine("\n");

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine(listaUm.Remove(45));
                Console.WriteLine(listaUm.Remove(45));
                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                listaUm.RemoveAt(0);
                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                listaUm.RemoveRange(0, 2);

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.Clear();

                for (int i = 0; i < 10; i++)
                {
                    listaUm.Add(i * 2);
                }

                listaUm.ForEach(x => Console.WriteLine(x));

                listaUm.Reverse();

                Console.WriteLine();

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.Clear();

                Console.WriteLine(listaUm.First());

                Console.WriteLine(listaUm.FirstOrDefault());

                Console.WriteLine();

                List<int> listaVazia = new List<int>();

                Console.WriteLine(listaVazia.FirstOrDefault());
                //Console.WriteLine(listaVazia.First()); // System.InvalidOperationException: 'Sequence contains no elements'

                Console.Clear();

                listaUm.ForEach(x => Console.WriteLine(x));

                for (int i = 0; i < 10; i++)
                {
                    listaUm.Add(i * 2);
                }

                listaUm.ForEach(x => Console.WriteLine(x));

                Console.WriteLine();

                var conjunto = listaUm.ToHashSet();

                foreach(int item in conjunto)
                {
                    Console.WriteLine(item);
                }


                return "Aula 2";
            });
        }
    }
}

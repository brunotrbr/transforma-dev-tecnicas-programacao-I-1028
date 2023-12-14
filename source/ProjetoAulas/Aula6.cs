using System.Globalization;
using CsvHelper;

namespace ProjetoAulas
{
    public static class Aula6
    {
        public static void MapAula6Endpoints(this WebApplication app)
        {
            var categorias = CarregarCategorias();
            var produtos = CarregarProdutos();

            app.MapGet("/aula_6", () =>
            {   
                var consulta =
                from categoria in categorias
                select categoria;

                var resultado = consulta.ToList();
                return "teste";
            });
        }

        static List<Categorias> CarregarCategorias(){
            using (var reader = new StreamReader("arquivos/categorias.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Categorias>();
                return records.ToList();
            }
        }

        static List<Produtos> CarregarProdutos(){
            using (var reader = new StreamReader("arquivos/produtos.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Produtos>().ToList();
            }
        }
    }

    public class Categorias
    {
        public int id { get; set; }
        public string nome { get; set; }

        public Categorias(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }

    public class Produtos
    {
        public int id {get; set;}

        public string nome {get; set;}

        public string descricao {get; set;}

        public double preco {get; set;}

        public int id_categoria {get; set;}


        public Produtos(int id, string nome, string descricao, double preco, int id_categoria)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.id_categoria = id_categoria;
        }
    }

    
}
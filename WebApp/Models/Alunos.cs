using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Alunos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public string data { get; set; }
        public int ra { get; set; }
        public string descricao { get; set; }

        /// <summary>
        /// deserializa e converte o json para passar a uma lista de alunos.
        /// </summary>
        /// <returns></returns>
        public List<Alunos> listarAlunos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAlunos = JsonConvert.DeserializeObject<List<Alunos>>(json);

            return listaAlunos;
        }
        

        public List<Alunos> listarAlunosDB()
        {
            string stringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Git\CriptX\WebAppAluno\WebApp\App_Data\Database.mdf;Integrated Security=True";
            
            IDbConnection conexao;
                
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
            var listaAlunos = new List<Alunos>();
            IDbCommand selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "select * from Alunos";

            IDataReader resultado = selectCmd.ExecuteReader();

            while (resultado.Read())
            {
                var alu = new Alunos();
                alu.id = Convert.ToInt32(resultado["id"]);
                alu.nome = Convert.ToString(resultado["nome"]);
                alu.sobrenome = Convert.ToString(resultado["sobrenome"]);
                alu.telefone = Convert.ToString(resultado["telefone"]);
                alu.data = Convert.ToString(resultado["data"]);
                alu.ra = Convert.ToInt32(resultado["ra"]);
                alu.descricao = Convert.ToString(resultado["descricao"]);

                listaAlunos.Add(alu);

            }
            conexao.Close();
            return listaAlunos;
        }


        /// <summary>
        /// Serializable
        /// Uso para serializar o que eu mando na API para o JSON
        /// </summary>
        /// <param name="listaAlunos"></param>
        /// <returns></returns>
        public bool ReescreverArquivos(List<Alunos> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        /// <summary>
        ///  Usa o listaAlunos para inserir um novo aluno no método "ReescreverArquivos"
        /// </summary>
        /// <param name="Aluno"></param>
        /// <returns></returns>
        public Alunos Inserir(Alunos Aluno)
        {
            var listaAlunos = this.listarAlunos();

            var maxId = listaAlunos.Max(aluno => aluno.id); // busca o maior ID na minha lista de alunos
            Aluno.id = maxId + +1;
            listaAlunos.Add(Aluno);

            ReescreverArquivos(listaAlunos);
            return Aluno;
        }

        /// <summary>
        /// Método de atualizar aluno (pesquisando pelo ID)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Aluno"></param>
        /// <returns></returns>
        public Alunos Atualizar(int id, Alunos Aluno)
        {
            var listaAlunos = this.listarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.id == id); //se ele encontrar num index o aluno que estou passando (ID)
            if (itemIndex >= 0)
            {
                Aluno.id = id;
                listaAlunos[itemIndex] = Aluno; //substitui alguma propriedade do aluno com um objeto que estou enviando
            }
            else
            {
                return null;
            }

            ReescreverArquivos(listaAlunos);
            return Aluno;
        }

        /// <summary>
        /// Delentado aluno passando o paramentro do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Deletar(int id)
        {
            var listaAluno = this.listarAlunos();

            var itemIndex = listaAluno.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaAluno.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            ReescreverArquivos(listarAlunos());
            return true;

        }
    }
}
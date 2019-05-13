using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public List<Alunos> listarAlunos(int? id = null)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                return alunoBD.listarAlunosDB(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao listar alunos: Erro = {ex.Message}");
            }

            
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
        public void Inserir(Alunos aluno)
        {
            //var listaAlunos = this.listarAlunos();

            //var maxId = listaAlunos.Max(aluno => aluno.id); // busca o maior ID na minha lista de alunos
            //Aluno.id = maxId + +1;
            //listaAlunos.Add(Aluno);

            //ReescreverArquivos(listaAlunos);
            //return Aluno;
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao inserir aluno: Erro = {ex.Message}");
            }

        }

        /// <summary>
        /// Método de atualizar aluno (pesquisando pelo ID)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Aluno"></param>
        /// <returns></returns>
        public void Atualizar(Alunos aluno)
        {
            //var listaAlunos = this.listarAlunos();

            //var itemIndex = listaAlunos.FindIndex(p => p.id == id); //se ele encontrar num index o aluno que estou passando (ID)
            //if (itemIndex >= 0)
            //{
            //    Aluno.id = id;
            //    listaAlunos[itemIndex] = Aluno; //substitui alguma propriedade do aluno com um objeto que estou enviando
            //}
            //else
            //{
            //    return null;
            //}

            //ReescreverArquivos(listaAlunos);
            //return Aluno;

            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar aluno: Erro = {ex.Message}");
            }
        }

        /// <summary>
        /// Delentado aluno passando o paramentro do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Deletar(int id)
        {
            //var listaAluno = this.listarAlunos();

            //var itemIndex = listaAluno.FindIndex(p => p.id == id);
            //if (itemIndex >= 0)
            //{
            //    listaAluno.RemoveAt(itemIndex);
            //}
            //else
            //{
            //    return false;
            //}
            //ReescreverArquivos(listarAlunos());
            //return true;
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Deletar aluno: Erro = {ex.Message}");
            }
        }
    }
}
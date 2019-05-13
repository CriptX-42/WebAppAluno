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
    public class AlunosModel
    {
        
        /// <summary>
        /// deserializa e converte o json para passar a uma lista de alunos.
        /// </summary>
        /// <returns></returns>
        public List<AlunoDTO> listarAlunos(int? id = null)
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
        ///  Usa o listaAlunos para inserir um novo aluno no método "ReescreverArquivos"
        /// </summary>
        /// <param name="Aluno"></param>
        /// <returns></returns>
        public void Inserir(AlunoDTO aluno)
        {
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
        public void Atualizar(AlunoDTO aluno)
        {
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
using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.RepositoryL
{
    public class AlunoDAO
    {
        public string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        public IDbConnection conexao;
        public AlunoDAO()
        {
            //string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
            
             conexao = new SqlConnection(stringConexao);

            conexao.Open();
        }

        public List<AlunoDTO> listarAlunosDB(int? id)
        {
            try
            {
                var listaAlunos = new List<AlunoDTO>();
                IDbCommand selectCmd = conexao.CreateCommand();
                if (id == null)
                {
                    selectCmd.CommandText = "select * from Aluno";
                }
                else
                {
                    selectCmd.CommandText = $"select * from Aluno where id = {id}";
                }

                
                IDataReader resultado = selectCmd.ExecuteReader();

                while (resultado.Read())
                {
                    var alu = new AlunoDTO();
                    alu.id = Convert.ToInt32(resultado["id"]);
                    alu.nome = Convert.ToString(resultado["nome"]);
                    alu.sobrenome = Convert.ToString(resultado["sobrenome"]);
                    alu.telefone = Convert.ToString(resultado["telefone"]);
                    alu.data = Convert.ToString(resultado["data"]);
                    alu.ra = Convert.ToInt32(resultado["ra"]);
                    alu.descricao = Convert.ToString(resultado["descricao"]);

                    listaAlunos.Add(alu);

                }

                return listaAlunos;
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            
        }
        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Aluno (nome, sobrenome, telefone, ra, data, descricao) values (@nome, @sobrenome, @telefone, @ra, @data, @descricao)";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                insertCmd.Parameters.Add(paramSobrenome);

                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                insertCmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                insertCmd.Parameters.Add(paramRa);

                IDbDataParameter paramData = new SqlParameter("data", aluno.data);
                insertCmd.Parameters.Add(paramData);

                IDbDataParameter paramDescricao = new SqlParameter("descricao", aluno.descricao);
                insertCmd.Parameters.Add(paramDescricao);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            
        }

        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand UpdateCmd = conexao.CreateCommand();
                UpdateCmd.CommandText = "Update Aluno SET nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra, data = @data, descricao = @descricao " +
                    "WHERE id = @id";

                IDbDataParameter paramId = new SqlParameter("id", aluno.id);
                UpdateCmd.Parameters.Add(paramId);

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                UpdateCmd.Parameters.Add(paramNome);

                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                UpdateCmd.Parameters.Add(paramSobrenome);

                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                UpdateCmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                UpdateCmd.Parameters.Add(paramRa);

                IDbDataParameter paramData = new SqlParameter("data", aluno.data);
                UpdateCmd.Parameters.Add(paramData);

                IDbDataParameter paramDescricao = new SqlParameter("descricao", aluno.descricao);
                UpdateCmd.Parameters.Add(paramDescricao);

                UpdateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand DeleteCmd = conexao.CreateCommand();
                DeleteCmd.CommandText = "delete from Aluno where id = @id";

                IDbDataParameter paramId = new SqlParameter("id", id);
                DeleteCmd.Parameters.Add(paramId);

                DeleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            
        }
    }
}
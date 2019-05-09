﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public int ra { get; set; }

        /// <summary>
        /// deserializa e converte o json para passar a uma lista de alunos.
        /// </summary>
        /// <returns></returns>
        public List<Aluno> ListarAlunos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return listaAlunos;
        }

        /// <summary>
        /// Serializable
        /// Uso para serializar o que eu mando na API para o JSON
        /// </summary>
        /// <param name="listaAlunos"></param>
        /// <returns></returns>
        public bool ReescreverArquivos(List<Aluno> listaAlunos)
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
        public Aluno Inserir(Aluno Aluno)
        {
            var listaAlunos = this.ListarAlunos();

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
        public Aluno Atualizar(int id, Aluno Aluno)
        {
            var listaAlunos = this.ListarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.id == id); //se ele encontrar num index o aluno que estou passando (ID)
            if(itemIndex >= 0)
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
            var listaAlunos = this.ListarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.id == id);
            if(itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            ReescreverArquivos(listaAlunos);
            return true;

        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Alunos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public int ra { get; set; }

        public List<Alunos> listaAlunos()
        {
            Alunos aluno = new Alunos();
            aluno.id = 1;
            aluno.nome = "Letícia";
            aluno.sobrenome = "Sena";
            aluno.telefone = "1234";
            aluno.ra = 12344321;

            Alunos aluno1 = new Alunos();
            aluno1.id = 2;
            aluno1.nome = "Ricardo";
            aluno1.sobrenome = "Carvalho";
            aluno1.telefone = "321";
            aluno1.ra = 321;

            List<Alunos> listaAlunos = new List<Alunos>();

            listaAlunos.Add(aluno);
            listaAlunos.Add(aluno1);

            return listaAlunos;
        }
    }
}
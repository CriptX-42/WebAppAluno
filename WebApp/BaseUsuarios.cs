using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public static class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Nome = "ricardo", Senha = "123456789", Funcoe= new string[] { Funcao.Admin } },
            };
        }
    }
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string[] Funcoe { get; set; }
    }
    public class Funcao
    {
        public const string Aluno = "Aluno";
        public const string Professor = "Aluno";
        public const string Admin = "Aluno";
    }
}
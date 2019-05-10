using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        public IHttpActionResult Get()
        {
            try
            {
                Alunos aluno = new Alunos();
                return Ok(aluno.ListarAlunos());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public Alunos Get(int id)
        {
            Alunos aluno = new Alunos();
            return aluno.ListarAlunos().Where(x => x.id == id).FirstOrDefault();
        }

        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9][4]\-[0-9][2])}/{nome:minlength(5)}")]
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                Alunos aluno = new Alunos();
                IEnumerable<Alunos> alunos = aluno.ListarAlunos().Where(x => x.data == data || x.nome == nome);
                if (!alunos.Any())
                {
                    return NotFound();
                }
                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        public List<Alunos> Post(Alunos aluno)
        {
            List<Alunos> alunos = new List<Alunos>();
            alunos.Add(aluno);

            return alunos;
        }

        // PUT: api/Aluno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
        }
    }
}
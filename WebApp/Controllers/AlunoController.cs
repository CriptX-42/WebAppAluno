﻿using System;
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
                return Ok(aluno.listarAlunos());
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
            return aluno.listarAlunos(id).FirstOrDefault();
        }

        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(3)}")]
        public IHttpActionResult Recuperar(string data, string nome = null)
        {
            try
            {
                Alunos aluno = new Alunos();
                IEnumerable<Alunos> alunos = aluno.listarAlunos().Where(x => x.data == data && x.nome == nome);
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
        [HttpPost]
        public IHttpActionResult Post(Alunos aluno)
        {
            try
            {
                Alunos _aluno = new Alunos();
                _aluno.Inserir(aluno);
                return Ok(_aluno.listarAlunos());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // PUT: api/Aluno/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Alunos aluno)
        {
            try
            {
                Alunos _aluno = new Alunos();
                aluno.id = id;
                _aluno.Atualizar(aluno);
                return Ok(_aluno.listarAlunos(id).FirstOrDefault());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Alunos _aluno = new Alunos();
                _aluno.Deletar(id);
                return Ok("Deletado com Sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
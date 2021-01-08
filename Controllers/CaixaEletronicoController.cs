using CadastroCedulas.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCedulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaEletronicoController : ControllerBase
    {
        private readonly Context _context;

        public CaixaEletronicoController(Context context)
        {
            _context = context;
        }

        // GET: api/CaixaEletronico
        [HttpGet]
        public ActionResult Get()
        {
            var caixas = _context.Cedulas.ToList();
            return Ok(caixas);
        }

        // GET api/CaixaEletronico/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var caixas = _context.CaixaEletronico.FirstOrDefault(n => n.Id == id);

            if (caixas == null)
                return BadRequest("Cedula não encontrada!");

            return Ok(caixas);
        }

        // POST api/CaixaEletronico
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/CaixaEletronico/5
        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            var caixas = _context.CaixaEletronico.FirstOrDefault(n => n.Id == id);

            if (caixas == null)
                return BadRequest("Caixa não encontrado!");

            _context.Remove(caixas);
            _context.SaveChanges();

            return Ok(caixas);
        }

        // DELETE api/CaixaEletronico/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var caixas = _context.CaixaEletronico.FirstOrDefault(n => n.Id == id);

            if (caixas == null)
                return BadRequest("Caixa não encontrado!");

            _context.Remove(caixas);
            _context.SaveChanges();

            return Ok();
        }
        // DELETE api/CaixaEletronico
        [HttpDelete("sacar/{id}")]
        public ActionResult Saca(int id)
        {
            var saque = 10000;
            var saldo = 50000;

            
            if (saque > saldo)
            {
                var n100 = _context.Cedulas.Where(n => n.Valor == 100);
                var n50 = _context.Cedulas.Where(n => n.Valor == 50);
                var n20 = _context.Cedulas.Where(n => n.Valor == 20);
                var n10 = _context.Cedulas.Where(n => n.Valor == 10);
                var n5 = _context.Cedulas.Where(n => n.Valor == 5);

                int nota100, nota50, nota20, nota10, nota5;
                int resto100, resto50, resto20, resto10, resto5;

                foreach (var item100 in n100)
                {
                    var soma100 = item100.Valor++;

                    if (soma100 > 0)
                    {
                        nota100 = saque / 100;
                        resto100 = saque % 100;

                        if (nota100 > 0)
                        {
                            return Ok("Cédulas de 100: " + nota100);
                        }

                        foreach (var item50 in n50)
                        {
                            var soma50 = item50.Valor++;

                            if (soma50 > 0)
                            {
                                nota50 = resto100 / 50;
                                resto50 = resto100 % 50;

                                if (nota50 > 0)
                                {
                                    return Ok("Cédulas de 100: " + nota50);
                                }

                                foreach (var item20 in n20)
                                {
                                    var soma20 = item20.Valor++;

                                    if (soma20 > 0)
                                    {
                                        nota20 = resto50 / 20;
                                        resto20 = resto50 % 20;

                                        if (nota20 > 0)
                                        {
                                            return Ok("Cédulas de 20: " + nota20);
                                        }

                                        foreach (var item10 in n10)
                                        {
                                            var soma10 = item10.Valor++;

                                            if (soma10 > 0)
                                            {
                                                nota10 = resto20 / 10;
                                                resto10 = resto20 % 10;

                                                if (nota10 > 0)
                                                {
                                                    return Ok("Cédulas de 10: " + nota10);
                                                }

                                                foreach (var item5 in n5)
                                                {
                                                    var soma5 = item5.Valor++;

                                                    if (soma5 > 0)
                                                    {
                                                        nota5 = resto10 / 5;
                                                        resto5 = resto10 % 5;

                                                        if (nota5 > 0)
                                                        {
                                                            return Ok("Cédulas de 5: " + nota5);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (soma100 <= 0)
                    {
                        foreach (var item50 in n50)
                        {
                            var soma50 = item50.Valor++;

                            if (soma50 > 0)
                            {
                                nota50 = saque / 50;
                                resto50 = saque % 50;

                                if (nota50 > 0)
                                {
                                    return Ok("Cédulas de 100: " + nota50);
                                }

                                foreach (var item20 in n20)
                                {
                                    var soma20 = item20.Valor++;

                                    if (soma20 > 0)
                                    {
                                        nota20 = resto50 / 20;
                                        resto20 = resto50 % 20;

                                        if (nota20 > 0)
                                        {
                                            return Ok("Cédulas de 20: " + nota20);
                                        }

                                        foreach (var item10 in n10)
                                        {
                                            var soma10 = item10.Valor++;

                                            if (soma10 > 0)
                                            {
                                                nota10 = resto20 / 10;
                                                resto10 = resto20 % 10;

                                                if (nota10 > 0)
                                                {
                                                    return Ok("Cédulas de 10: " + nota10);
                                                }

                                                foreach (var item5 in n5)
                                                {
                                                    var soma5 = item5.Valor++;

                                                    if (soma5 > 0)
                                                    {
                                                        nota5 = resto10 / 5;
                                                        resto5 = resto10 % 5;

                                                        if (nota5 > 0)
                                                        {
                                                            return Ok("Cédulas de 5: " + nota5);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (soma50 <= 0)
                            {
                                foreach (var item20 in n20)
                                {
                                    var soma20 = item20.Valor++;

                                    if (soma20 > 0)
                                    {
                                        nota20 = saque / 20;
                                        resto20 = saque % 20;

                                        if (nota20 > 0)
                                        {
                                            return Ok("Cédulas de 20: " + nota20);
                                        }

                                        foreach (var item10 in n10)
                                        {
                                            var soma10 = item10.Valor++;

                                            if (soma10 > 0)
                                            {
                                                nota10 = resto20 / 10;
                                                resto10 = resto20 % 10;

                                                if (nota10 > 0)
                                                {
                                                    return Ok("Cédulas de 10: " + nota10);
                                                }

                                                foreach (var item5 in n5)
                                                {
                                                    var soma5 = item5.Valor++;

                                                    if (soma5 > 0)
                                                    {
                                                        nota5 = resto10 / 5;
                                                        resto5 = resto10 % 5;

                                                        if (nota5 > 0)
                                                        {
                                                            return Ok("Cédulas de 5: " + nota5);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (soma20 <= 0)
                                    {
                                        foreach (var item10 in n10)
                                        {
                                            var soma10 = item10.Valor++;

                                            if (soma10 > 0)
                                            {
                                                nota10 = saque / 10;
                                                resto10 = saque % 10;

                                                if (nota10 > 0)
                                                {
                                                    return Ok("Cédulas de 10: " + nota10);
                                                }

                                                foreach (var item5 in n5)
                                                {
                                                    var soma5 = item5.Valor++;

                                                    if (soma5 > 0)
                                                    {
                                                        nota5 = resto10 / 5;
                                                        resto5 = resto10 % 5;

                                                        if (nota5 > 0)
                                                        {
                                                            return Ok("Cédulas de 5: " + nota5);
                                                        }
                                                    }
                                                }
                                            }

                                            if (soma10 <= 0)
                                            {
                                                foreach (var item5 in n5)
                                                {
                                                    var soma5 = item5.Valor++;

                                                    if (soma5 > 0)
                                                    {
                                                        nota5 = saque / 5;
                                                        resto5 = saque % 5;

                                                        if (nota5 > 0)
                                                        {
                                                            return Ok("Cédulas de 5: " + nota5);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }

                }

                return Ok("Saque no valor de: " + saque + "realizado com sucesso!");
            }

            return BadRequest("Saldo insuficiente, saque um valor igual ou inferior a: " + saldo);
        }
    }
}

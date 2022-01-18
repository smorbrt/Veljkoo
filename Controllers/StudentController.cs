using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace AJMO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public FakultetContext Context{get; set;}
        public StudentController(FakultetContext context)
        {
            Context=context;
        
        }
        
        [Route("Preuzmi")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            return Ok(Context.Studenti);
        }

        [EnableCors("CORS")]
        [Route("DodatiStudenta")]
        [HttpPost]
        public async Task<ActionResult> DodajStudenta([FromBody] Student student)
        {
            if (student.Indeks < 10000 || student.Indeks > 20000)
            {
                return BadRequest("Pogrešan Indeks!");
            }

            if (string.IsNullOrWhiteSpace(student.Ime) || student.Ime.Length > 50)
            {
                return BadRequest("Pogrešno ime!");
            }

            if (string.IsNullOrWhiteSpace(student.Prezime) || student.Prezime.Length > 50)
            {
                return BadRequest("Pogrešno prezime!");
            }

            try
            {
                Context.Studenti.Add(student);
                await Context.SaveChangesAsync();
                return Ok($"Student je dodat! ID je: {student.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromenitiStudenta/{indeks}/{ime}/{prezime}")]
        [HttpPut]
        public async Task<ActionResult> Promeni(int indeks, string ime, string prezime)
        {
            if (indeks < 10000 || indeks > 20000)
                return BadRequest("Pogrešan indeks!");                                            
            try
            {
                var student = Context.Studenti.Where(p => p.Indeks == indeks).FirstOrDefault();

                if (student != null)
                {
                    student.Ime = ime;
                    student.Prezime = prezime;

                    await Context.SaveChangesAsync();
                    return Ok($"Uspešno promenjen student! ID: {student.ID}");
                }
                else
                {
                    return BadRequest("Student nije pronađen!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisatiStudenta/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Izbrisi(int id)
        {
            if (id <= 0)
                return BadRequest("Pogrešan ID!");
            try
            {
                var student = await Context.Studenti.FindAsync(id);
                int indeks = student.Indeks;
                Context.Studenti.Remove(student);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan student sa Indeksom: {indeks}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
    }
}

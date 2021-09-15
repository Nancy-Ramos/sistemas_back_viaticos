using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSystemsATSM.Data;
using ApiSystemsATSM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSystemsATSM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorteController: ControllerBase
    {
        private readonly AtsmContext _context;

        public CorteController(AtsmContext context)
        {
            _context = context;
        }

        [HttpGet("all/{usuario}")]
        public async Task<ActionResult<IEnumerable<CorteModel>>> GetCortes(int usuario) 
        {
            var data = await _context.Corte
                    .Join(_context.Usuario, x => x.Usuario, y => y.Id, (x, y) => new { corte = x, nombreUsuario = y.Nombre })
                    .Where(x => x.corte.Usuario == usuario)
                    .ToListAsync();

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<CorteModel>> GetCorte([FromQuery] int id)
        {
            var corte = await _context
                        .Corte
                        .Join(_context.Concepto, x => x.Folio, y => y.Folio, (x, y) => new { corte = x, concepto = y } )
                        .Where(x => x.corte.Id == id)
                        .ToListAsync();

            return Ok(corte);
        }
        

        [HttpPost("last_corte")]
        public async Task<ActionResult<CorteModel>> PostCorte([FromQuery] int usuario)
        {
            CorteModel find_corte = await _context.Corte.Where(x => x.Usuario == usuario && x.IsTerminated == false).FirstOrDefaultAsync();
            
            if (find_corte == null)
            {
                CorteModel last_corte = await _context.Corte.OrderBy(x => x.Id).LastOrDefaultAsync();
                
                CorteModel corte = new CorteModel();

                corte.Folio = (last_corte == null) ? "RCA-1" : $"RCA-{ last_corte.Id }";
                corte.Fecha = DateTime.Now;
                corte.Usuario = usuario;

                _context.Corte.Add(corte);

                await _context.SaveChangesAsync();

                List<ConceptoModel> conceptos = new List<ConceptoModel>();

                return CreatedAtAction(nameof(GetCorte), new { id = corte.Id, corte.IsTerminated, corte.Folio, conceptos });
            }
            else
            {
                List<ConceptoModel> conceptos = await _context.Concepto.Where(x => x.Folio == find_corte.Folio).ToListAsync();

                return CreatedAtAction(nameof(GetCorte), new { id = find_corte.Id, find_corte.IsTerminated, find_corte.Folio, conceptos }); 
            }
        }

        [HttpPost("new_concept")]
        public async Task<ActionResult<ConceptoModel>> PostConcepto([FromBody] ConceptoModel concepto) 
        {
            _context.Concepto.Add(concepto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("conceptos_corte")]
        public async Task<ActionResult<IEnumerable<ConceptoModel>>> GetConceptoAsync([FromQuery] string folio)
        {
            List<ConceptoModel> conceptos = await _context.Concepto.Where(x => x.Folio == folio).ToListAsync();

            return Ok(conceptos);
        }

        [HttpDelete("concepto")]
        public async Task<ActionResult<ConceptoModel>> DeleteConcepto([FromQuery] int id)
        {
            var concepto = await _context.Concepto.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            _context.Concepto.Remove(concepto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CorteModel>> PutCorte([FromQuery] string folio)
        {
            var find_corte = await _context.Corte.Where(x => x.Folio == folio).FirstOrDefaultAsync();

            if (find_corte == null)
            {
                return NotFound();
            }

            find_corte.IsTerminated = true;

            _context.Entry(find_corte).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
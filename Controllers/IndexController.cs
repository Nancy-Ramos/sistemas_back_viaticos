using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSystemsATSM.Data;
using ApiSystemsATSM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiSystemsATSM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        private readonly AtsmContext _context;
        
        public IndexController(AtsmContext context)
        {
            _context = context;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<UsuarioModel>> Auth(UsuarioModel usuario)
        {   
            var findUser = await _context.Usuario.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefaultAsync();
            
            if (findUser == null)
            {
                return NotFound();
            }

            return findUser;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { msg = "Usuario registrado" });
        }
    }
}

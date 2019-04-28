using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogDeDados.Models;

namespace LogDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogDeDadosContext _context;

        public LogsController(LogDeDadosContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet]
        public IEnumerable<Log> GetLog()
        {
            var usuario = UsuarioToken(Request.Headers["Authorization"]);
            if (usuario == null)
                return null;
            return _context.Log.Where(l => l.IDUsuario == usuario.IDUsuario);
        }

        // POST: api/Logs
        [HttpPost]
        public async Task<IActionResult> PostLog([FromBody] Log log)
        {
            var usuario = UsuarioToken(Request.Headers["Authorization"]);
            if (usuario == null)
                return CreatedAtAction("Erro", "Token não Cadastrado");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            log.IDUsuario = usuario.IDUsuario;
            _context.Log.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Sucesso", "Log Castrado");
        }

        private Usuario UsuarioToken(string Token)
        {
            Guid guidResult;
            bool isValid = Guid.TryParse(Token, out guidResult);
            if (!isValid)
                return null;
            var usuario = _context.Usuario.FirstOrDefault(m => m.Token == guidResult);
            if (usuario == null)
                return null;

            return usuario;
        }
    }
}
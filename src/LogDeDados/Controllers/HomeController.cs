using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogDeDados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LogDeDados.Controllers
{
    public class HomeController : Controller
    {
        private readonly LogDeDadosContext _context;

        public HomeController(LogDeDadosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Get<Usuario>("UsuarioLogado") != null)
                return RedirectToAction(nameof(Dash));
            else return View();
        }
        public IActionResult Dash()
        {
            if (HttpContext.Session.Get<Usuario>("UsuarioLogado") == null)
                return RedirectToAction(nameof(Index));
            var usuario = HttpContext.Session.Get<Usuario>("UsuarioLogado");
            return View(usuario);
        }
        public async Task<IActionResult> Logar(string Email,string Senha)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == Email && u.Senha == Senha);
            if(usuario != null)
            {
                HttpContext.Session.Set<Usuario>("UsuarioLogado", usuario);
                return RedirectToAction(nameof(Dash));
            }
                
            else
                return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioLogado");
                return RedirectToAction(nameof(Index));
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

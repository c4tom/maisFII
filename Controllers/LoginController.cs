using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaisFII.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace MaisFII.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;


        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (LoginExist(email, senha))
            {
                HttpContext.Session.SetString("email", email);
                return View("Sucesso");
            }
            else
            {
                ViewBag.error = "Usuário/senha inválido";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index");
        }

        private bool LoginExist(string email, string senha)
        {
            return _context.Usuario.Any(e => e.Email == email && e.Senha == senha);
        }
    }
}

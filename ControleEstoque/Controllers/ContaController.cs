using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleEstoque.Controllers
{
    public class ContaController : Controller
    {
        //Tornando essa url publica para todos através do AllowAnonymous
       [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //metodo Post
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string ReturnUrl)
        {
            //condição se o usuário é valido, para retornar view de login caso false
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            //Criando uma variavel de teste com usuário e senha
            var usuario = UsuarioModel.ValidarUsuario(login.Usuario, login.Senha);

            //condição para usuário e senha corretos direcionando para Index, Home
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Nome, login.LembrarMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                     return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Inválido");
            }
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
using ProjetoTeste.NH.Config;
using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjetoTeste.WebSite.RolesSecurity
{
    public class UsuarioUtils
    {
        public static Usuario Usuario
        {
            get
            {
                Usuario user = null;
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    user = (Usuario)HttpContext.Current.Session["Usuario"];
                }

                return user;
            }
        }

        public static bool Logar(string Login, string Senha)
        {
            var usuario = ConfigDB.Instance.UsuarioRepository.BuscaPorLoginSenha(Login, Senha);
            
            if (usuario != null && usuario.Ativo) {
                FormsAuthentication.SetAuthCookie(usuario.Login, false);
                HttpContext.Current.Session["Usuario"] = usuario;
                return true;
            }
            return false; 
        }

        public static void Deslogar()
        {

            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
                        
            FormsAuthentication.SignOut();
        }
    }
}
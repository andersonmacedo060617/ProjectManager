using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ProjetoTeste.NH.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        
        public UsuarioRepository(ISession session) : base(session)
        {
        }

        public Usuario BuscaPorLogin(string Login)
        {
            var usuario = this.BuscarTodos().Where(x=>x.Login == Login).FirstOrDefault();

            return usuario;
        }

        public Usuario BuscaPorLoginSenha(string Login, string Senha)
        {
            var usuario = this.BuscarTodos().Where(
                x => x.Login == Login && x.Senha == Senha
                ).FirstOrDefault();

            return usuario;
        }


    }
}

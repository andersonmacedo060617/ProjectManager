using NHibernate;
using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.NH.Repository
{
    public class AcessoUsuarioRepository : BaseRepository<AcessoUsuario>
    {
        public AcessoUsuarioRepository(ISession session) : base(session)
        {
        }
    }
}

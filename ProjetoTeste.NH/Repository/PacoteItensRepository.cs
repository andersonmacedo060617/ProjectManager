using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ProjetoTeste.NH.Repository
{
    public class PacoteItensRepository : BaseRepository<PacoteItens>
    {
        public PacoteItensRepository(ISession session) : base(session)
        {
        }
    }
}

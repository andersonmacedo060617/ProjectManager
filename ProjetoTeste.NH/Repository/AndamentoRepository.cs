using NHibernate;
using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.NH.Repository
{
    public class AndamentoRepository : BaseRepository<Andamento>
    {
        
        public AndamentoRepository(ISession session) : base(session)
        {
        }
    }
}

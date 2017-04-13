using NHibernate;
using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.NH.Repository
{
    public class AtividadeRepository:BaseRepository<Atividade>
    {
        public AtividadeRepository(ISession session) : base(session)
        {
        }
    }
}

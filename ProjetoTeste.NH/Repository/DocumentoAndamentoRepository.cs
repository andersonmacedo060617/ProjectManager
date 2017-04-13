using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ProjetoTeste.NH.Repository
{
    public class DocumentoAndamentoRepository : BaseRepository<DocumentoAndamento>
    {
        public DocumentoAndamentoRepository(ISession session) : base(session)
        {
        }
    }
}

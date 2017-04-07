using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class DocumentoAndamento
    {
        public virtual int Id { get; set; }

        public virtual Andamento Andamento { get; set; }

        public virtual Documento Documento { get; set; }
    }

    public class DocumentoAndamentoMap : ClassMapping<DocumentoAndamento>
    {
        public DocumentoAndamentoMap()
        {
            Table("DocumentoAndamento");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            ManyToOne<Documento>(x => x.Documento, m =>
            {
                m.Column("IdDocumento");
            });

            ManyToOne<Andamento>(x => x.Andamento, m =>
            {
                m.Column("IdAndamento");
            });


        }
    }
}
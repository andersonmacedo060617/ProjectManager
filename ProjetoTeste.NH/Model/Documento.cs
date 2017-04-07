using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class Documento
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string CaminhoArquivo { get; set; }


    }

    public class DocumentoMap : ClassMapping<Documento>
    {
        public DocumentoMap()
        {
            Table("Documento");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.Descricao);
            Property<string>(x => x.CaminhoArquivo);

            
        }
    }
}
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class PacoteItensProjeto
    {
        public virtual int Id { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual PacoteItens Pacote { get; set; }

    }

    public class PacoteItensProjetoMap : ClassMapping<PacoteItensProjeto>
    {
        public PacoteItensProjetoMap()
        {
            Table("PacoteItens_Projeto");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });
            
            ManyToOne<Projeto>(x => x.Projeto, m =>
            {
                m.Column("IdProjeto");
            });

            ManyToOne<PacoteItens>(x => x.Pacote, m =>
            {
                m.Column("IdPacote");
            });

        }
    }
}
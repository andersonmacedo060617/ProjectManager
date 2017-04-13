using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class ResponsaveisProjeto
    {
        public virtual int Id { get; set; }

        public virtual Usuario Responsavel { get; set; }

        public virtual Funcao FormaParticipacao { get; set; }

    }

    public class ResponsaveisProjetoMap : ClassMapping<ResponsaveisProjeto>
    {
        public ResponsaveisProjetoMap()
        {
            Table("ResponsaveisProjeto");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            ManyToOne<Funcao>(x => x.FormaParticipacao, m =>
            {
                m.Column("IdFuncao");
            });

            ManyToOne<Usuario>(x => x.Responsavel, m =>
            {
                m.Column("IdResponsavel");
            });

        }
    }
}
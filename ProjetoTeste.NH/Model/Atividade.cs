using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace ProjetoTeste.NH.Model
{
    public class Atividade
    {
        public virtual int Id { get; set; }

        public virtual DateTime DataInicio { get; set; }
        
        public virtual TimeSpan Duracao { get; set; }

        public virtual TipoAtividade Tipo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual Usuario Responsavel { get; set; }
    }

    public class AtividadeMap : ClassMapping<Atividade>
    {
        public AtividadeMap()
        {
            Table("Atividade");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<DateTime>(x => x.DataInicio);
            Property<TimeSpan>(x => x.Duracao);
            Property<string>(x => x.Descricao);
            Property<TimeSpan>(x => x.Duracao);

            ManyToOne<TipoAtividade>(x => x.Tipo, m =>
            {
                m.Column("IdTipoAtividade");
            });

            ManyToOne<Usuario>(x => x.Responsavel, m =>
            {
                m.Column("IdUsuarioResponsavel");
            });



        }
    }
}
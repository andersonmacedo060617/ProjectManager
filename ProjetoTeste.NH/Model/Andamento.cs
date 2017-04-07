using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace ProjetoTeste.NH.Model
{
    public class Andamento
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string Texto { get; set; }

        public virtual DateTime Data {get; set; }

        public virtual Usuario Responsavel { get; set; }

        public virtual IList<DocumentoAndamento> Anexos { get; set; }
    }

    public class AndamentoMap : ClassMapping<Andamento>
    {
        public AndamentoMap()
        {
            Table("Andamento");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Descricao);
            Property<string>(x => x.Texto);
            Property<DateTime>(x => x.Data);
            
            ManyToOne<Usuario>(x => x.Responsavel, m =>
            {
                m.Column("IdUsuarioResponsavel");
            });

            Bag<DocumentoAndamento>(x => x.Anexos, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()              
            );

        }
    }
}
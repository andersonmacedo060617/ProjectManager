using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.NH.Model
{
    public class Projeto
    {
        public virtual int Id { get; set; }

        public virtual DateTime DataInicio { get; set; }

        public virtual DateTime DataFim { get; set; }

        public virtual string Descricao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual IList<ResponsaveisProjeto> ResponsaveisProjeto { get; set; }

        public virtual IList<PacoteItensProjeto> PacotesProjeto { get; set; } 

        public virtual IList<ItemProjeto> ItensAdicionaisProjeto { get; set; }

        public virtual IList<Documento> Documentos { get; set; }

        public virtual IList<Andamento> Andamentos { get; set; }

        public virtual IList<Atividade> Atividades { get; set; }
        
    }

    public class ProjetoMap : ClassMapping<Projeto>
    {
        public ProjetoMap()
        {
            Table("Projeto");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });
            
            Property<DateTime>(x => x.DataInicio);
            Property<DateTime>(x => x.DataFim);
            Property<string>(x => x.Descricao);
            
            ManyToOne<Cliente>(x => x.Cliente, m =>
            {
                m.Column("IdCliente");
            });

            Bag<ResponsaveisProjeto>(x => x.ResponsaveisProjeto, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag<PacoteItensProjeto>(x => x.PacotesProjeto, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag<ItemProjeto>(x => x.ItensAdicionaisProjeto, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag<Documento>(x => x.Documentos, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag<Andamento>(x => x.Andamentos, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            Bag<Atividade>(x => x.Atividades, m =>
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

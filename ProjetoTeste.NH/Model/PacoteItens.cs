using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Collections.Generic;

namespace ProjetoTeste.NH.Model
{
    public class PacoteItens
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual IList<ItemServico> Item { get; set; }

        public virtual bool Ativo { get; set; }
    }

    public class PacoteItensMap : ClassMapping<PacoteItens>
    {
        public PacoteItensMap()
        {
            Table("PacoteItens");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.Descricao);
            Property<bool>(x => x.Ativo);

            Bag<ItemServico>(x => x.Item, m =>
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
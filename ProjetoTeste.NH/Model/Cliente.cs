using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Collections;
using System.Collections.Generic;

namespace ProjetoTeste.NH.Model
{
    public class Cliente
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual IList<Projeto> Projetos { get; set; }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");

            Id<int>(x => x.Id, m =>
              {
                  m.Generator(Generators.Identity);
              });

            Property<string>(x => x.Nome);

            Bag<Projeto>(x => x.Projetos, m =>
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
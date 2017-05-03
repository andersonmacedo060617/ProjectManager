using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjetoTeste.NH.Repository;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.NH.Model
{
    public class Cliente
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "A Descrição é Obrigatorio.")]
        public virtual string Nome { get; set; }

        public virtual int Idade { get; set; }

        public virtual IList<Projeto> Projetos { get; set; }
        

        public virtual int QuantidadeProjetos
        {
            get
            {
                if(this.Projetos != null)
                {
                    return this.Projetos.Count;
                }
                return 0;
            }
        }
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
            Property<int>(x => x.Idade);

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
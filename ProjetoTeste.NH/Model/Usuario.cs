using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Collections.Generic;

namespace ProjetoTeste.NH.Model
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

        public virtual Funcao Cargo { get; set; }

        public virtual IList<AcessoUsuario> PerfilAcesso { get; set;}
        public virtual bool Admin { get; set; }
        public virtual bool Ativo { get; set; }
    }

    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.Login);
            Property<string>(x => x.Senha);
            Property<bool>(x => x.Admin);
            Property<bool>(x => x.Ativo);


            Bag<AcessoUsuario>(x => x.PerfilAcesso, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
            },
                r => r.OneToMany()
            );

            ManyToOne<Funcao>(x => x.Cargo, m =>
            {
                m.Column("IdFuncao");
            });

        }
    }
}
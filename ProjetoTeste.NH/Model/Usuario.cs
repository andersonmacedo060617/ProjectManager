using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

        public virtual Funcao Cargo { get; set; }
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

            ManyToOne<Funcao>(x => x.Cargo, m =>
            {
                m.Column("IdFuncao");
            });

        }
    }
}
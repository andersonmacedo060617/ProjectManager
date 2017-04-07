using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class TipoAtividade
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }
    }

    public class TipoAtividadeMap : ClassMapping<TipoAtividade>
    {
        public TipoAtividadeMap()
        {
            Table("TipoAtividade");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);

        }
    }
}

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class AcessoAcao
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NomeAction { get; set; }
    }
    public class AcessoAcaoMap : ClassMapping<AcessoAcao>
    {
        public AcessoAcaoMap()
        {
            Table("AcessoAcao");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.NomeAction);

        }
    }
}
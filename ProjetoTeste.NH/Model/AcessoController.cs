using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class AcessoController
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NomeController { get; set; }
        
    }

    public class AcessoControllerMap : ClassMapping<AcessoController>
    {
        public AcessoControllerMap()
        {
            Table("AcessoController");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.NomeController);

        }
    }
}
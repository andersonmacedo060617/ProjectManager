using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProjetoTeste.NH.Model
{
    public class AcessoUsuario
    {
        public virtual int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual AcessoController AcessoController { get; set; }
        public virtual AcessoAcao AcessoAcao { get; set; }
    }
    public class AcessoUsuarioMap : ClassMapping<AcessoUsuario>
    {
        public AcessoUsuarioMap()
        {
            Table("Acesso_Usuario");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            ManyToOne<Usuario>(x => x.Usuario, m =>
            {
                m.Column("IdUsuario");
            });
            ManyToOne<AcessoController>(x => x.AcessoController, m =>
            {
                m.Column("IdAcessoController");
            });

            ManyToOne<AcessoController>(x => x.AcessoController, m =>
            {
                m.Column("IdAcesoAcao");
            });

        }
    }
}
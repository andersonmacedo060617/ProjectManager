using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Web;
using NHibernate.Context;
using System.Reflection;
using ProjetoTeste.NH.Model;
using ProjetoTeste.NH.Repository;

namespace ProjetoTeste.NH.Config
{
    public class ConfigDB
    {
        public static string StringConexao =
            "Persist Security Info=False;server=localhost;port=3306;" +
            "database=ProjectManager;uid=root;pwd=plkadmin2002";

        private ISessionFactory SessionFactory;

        private static ConfigDB _instance = null;

        #region Repository
        public AcessoAcaoRepository AcessoAcaoRepository { get; set; }
        public AcessoControllerRepository AcessoControllerRepository { get; set; }
        public AcessoUsuarioRepository AcessoUsuarioRepository { get; set; }
        public AndamentoRepository AndamentoRepository { get; set; }
        public AtividadeRepository AtividadeRepository { get; set; }
        public ClienteRepository ClienteRepository { get; set; }
        public DocumentoRepository DocumentoRepository { get; set; }
        public DocumentoAndamentoRepository DocumentoAndamentoRepository { get; set; }
        public FuncaoRepository FuncaoRepository { get; set; }
        public ItemProjetoRepository ItemProjetoRepository { get; set; }
        public PacoteItensRepository PacoteItensRepository { get; set; }
        public PacoteItensProjetoRepository PacoteItensProjetoRepository { get; set; }
        public ProjetoRepository ProjetoRepository { get; set; }
        public ResponsaveisProjetoRepository ResponsaveisProjetoRepository { get; set; }
        public TipoAtividadeRepository TipoAtividadeRepository { get; set; }
        public UsuarioRepository UsuarioRepository { get; set; }
        #endregion


        #region Config
        public static ConfigDB Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ConfigDB();
                }

                return _instance;
            }
        }
        #endregion

        #region Construtor ConfigDB
        public ConfigDB()
        {
            if (Conexao())
            {
                this.AcessoAcaoRepository = new AcessoAcaoRepository(this.Session);
                this.AcessoControllerRepository = new AcessoControllerRepository(this.Session);
                this.AcessoUsuarioRepository = new AcessoUsuarioRepository(this.Session);
                this.AndamentoRepository = new AndamentoRepository(this.Session);
                this.AtividadeRepository = new AtividadeRepository(this.Session);
                this.ClienteRepository = new ClienteRepository(this.Session);
                this.DocumentoAndamentoRepository = new DocumentoAndamentoRepository(this.Session);
                this.DocumentoRepository = new DocumentoRepository(this.Session);
                this.FuncaoRepository = new FuncaoRepository(this.Session);
                this.ItemProjetoRepository = new ItemProjetoRepository(this.Session);
                this.PacoteItensProjetoRepository = new PacoteItensProjetoRepository(this.Session);
                this.PacoteItensRepository = new PacoteItensRepository(this.Session);
                this.ProjetoRepository = new ProjetoRepository(this.Session);
                this.ResponsaveisProjetoRepository = new ResponsaveisProjetoRepository(this.Session);
                this.TipoAtividadeRepository = new TipoAtividadeRepository(this.Session);
                this.UsuarioRepository = new UsuarioRepository(this.Session);
            }
        }
        #endregion


        #region Mapeamento
        private HbmMapping Mapeamento()
        {
            try
            {
                var mapper = new ModelMapper();

                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(AcessoAcaoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(AcessoControllerMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(AcessoUsuarioMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(AndamentoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(AtividadeMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(ClienteMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(DocumentoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(DocumentoAndamentoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(FuncaoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(ItemProjetoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(PacoteItensMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(PacoteItensProjetoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(Projeto)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(ResponsaveisProjetoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(TipoAtividade)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(UsuarioMap)).GetTypes()
                );
                
                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch
            {
                throw;
            }
        }
        #endregion
        
        #region Conexao
        private bool Conexao()
        {
            //Cria a configuração com o NH

            var config = new NHibernate.Cfg.Configuration();
            try
            {
                //Integração com o banco de dados
                config.DataBaseIntegration(c => {
                    //Dialeto do banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //String de conexão
                    c.ConnectionString = StringConexao;
                    //Driver de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    //Provedor de conexão do MySQL
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    //Gera Log dos  comenados exercutados no console
                    c.LogSqlInConsole = true;
                    //Cria o schema do banco de dados sempre que a configuration for utilizada
                    c.SchemaAction = SchemaAutoAction.Update;
                    
                });

                //Realiza o mapeamento das classes
                var maps = this.Mapeamento();
                config.AddMapping(maps);

                if(HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this.SessionFactory = config.BuildSessionFactory();

                return true;

            }
            catch
            {
                throw;
            }
        }
        #endregion
        
        #region Session
        private ISession Session
        {
            get
            {
                try
                {
                    if (CurrentSessionContext.HasBind(SessionFactory))
                    {
                        return SessionFactory.GetCurrentSession();
                    }

                    var session = SessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                    return session;
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion



    }
}

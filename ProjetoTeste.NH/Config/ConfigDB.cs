using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Web;
using NHibernate.Context;

namespace ProjetoTeste.NH.Config
{
    public class ConfigDB
    {
        public static string StringConexao = "Persist Security Info=False;server=192.168.11.200;port=3306;" +
        "database=GerenciadorLixoEletronico;uid=root;pwd=root";

        private ISessionFactory SessionFactory;

        private static ConfigDB _instance = null;
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

        #region Mapeamento
        private HbmMapping Mapeamento()
        {
            try
            {
                var mapper = new ModelMapper();

                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Repository

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

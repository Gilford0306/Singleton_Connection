using Singleton_Connection.Model;
using System.Data.SqlClient;
namespace Singleton_Connection.Controler
{
    internal class SingletonConnection
    {

        private static SingletonConnection _instance = null;
        public static SqlConnection sqlstr { get; private set; }

        private SingletonConnection(string ConnectionStr)
        {
            sqlstr = new SqlConnection(ConnectionStr);

        }
        public SqlConnection GetConnection() => sqlstr;


        public static SingletonConnection GetInstance(ModelSettings settings)
        {

            if (_instance == null)
            {
                
               _instance = new SingletonConnection(settings.ToString());
            }
            if (sqlstr.State != System.Data.ConnectionState.Open)
                sqlstr.Open();
            return _instance;
        }
        
    }
}

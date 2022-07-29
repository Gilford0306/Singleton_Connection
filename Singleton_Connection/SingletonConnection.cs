using System.Data.SqlClient;
namespace Singleton_Connection
{
    internal class SingletonConnection
    {

        private static string ConnectionStr = string.Empty;
        private static SingletonConnection _instance = null;
        public static SqlConnection sqlstr { get; private set; }

        private SingletonConnection(string ConnectionStr)
        {
            sqlstr = new SqlConnection(ConnectionStr);
            sqlstr.Open();
        }

        public static SingletonConnection GetInstance()
        {

            if (_instance == null)
            {
                const string fileName = "myFile.txt";
                ConnectionStr = File.ReadAllText(fileName);
                _instance = new SingletonConnection(ConnectionStr);
            }
            return _instance;
        }
    }
}

using System.Data.SqlClient;
namespace Singleton_Connection
{
    class UserTable
    {
        User[] arr = new User[0];

        public UserTable()
        {
            SingletonConnection sq = SingletonConnection.GetInstance();
            Console.WriteLine(SingletonConnection.GetInstance());
            using (SingletonConnection.sqlstr)
            {
                using (SqlCommand cmd = new SqlCommand(" SELECT * FROM[Note].[dbo].[user]",SingletonConnection.sqlstr))

                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = user;
                    }
                }
            }
        }

        public void Show()
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

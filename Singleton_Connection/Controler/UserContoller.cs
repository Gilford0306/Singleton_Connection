using Singleton_Connection.Model;
using System.Data.SqlClient;

namespace Singleton_Connection.Controler
{
    class UserContoller
    {
        List<User> users = new List<User>();

        public UserContoller(SqlConnection con)
        {


            using (SqlCommand cmd = new SqlCommand(" SELECT * FROM[Note].[dbo].[user]", con))

            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
            }


        }

        public void Show()
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}

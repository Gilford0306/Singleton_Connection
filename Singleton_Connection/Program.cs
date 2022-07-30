using Singleton_Connection.Controler;



ConnectionControler controller1 = new ConnectionControler(@"D:\Projects\Singleton_Connection\Singleton_Connection\Settings\dbSetting.json");
controller1.Download();
UserContoller userTable = new UserContoller(SingletonConnection.GetInstance(controller1.defaultsetting).GetConnection());
userTable.Show();
userTable = new UserContoller(SingletonConnection.GetInstance(controller1.defaultsetting).GetConnection());
userTable.Show();



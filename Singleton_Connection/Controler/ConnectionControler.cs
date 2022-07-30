using System.Text.Json;
using Singleton_Connection.Model;

namespace Singleton_Connection.Controler
{
    internal class ConnectionControler
    {
        readonly string fileName;
        public ModelSettings defaultsetting { get; set; }
        public ConnectionControler(string fileName = "setting.json")
        {
            this.fileName = fileName;
            
        }
        public void Download() => defaultsetting = JsonSerializer.Deserialize<ModelSettings>(File.ReadAllText(fileName));
        public void SetSettings(ModelSettings setting)
        {
            defaultsetting = setting;

        }
        public void Save() => File.WriteAllText(fileName, JsonSerializer.Serialize<ModelSettings>(defaultsetting));

    }
}

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class Repository<T>
    {
        public void Serialize(List<T> employees, string jsonPath)
        {
            File.Delete(jsonPath);
            StreamWriter fileEmployees = File.CreateText(jsonPath);
            string json = JsonConvert.SerializeObject(employees, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            });
            
            fileEmployees.Write(json);
            fileEmployees.Close();
        }
        
        public List<T> DeSerialize(string jsonPath)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(jsonPath));
        }
    }
}
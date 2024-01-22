using Newtonsoft.Json;
using NLog;
using RestSharp;
using SeleniumNUnit.Business.API.Models.Response;

namespace SeleniumNUnit.Business.API.APIUtils
{
    public class ResponseConverter
    {
        public static List<User> GetDeserializedCollection<T>(RestResponse response)
        {
            var content = response.Content;
            List<User> deserializedCollection = JsonConvert.DeserializeObject<List<User>>(content);
            foreach (var user in deserializedCollection)
            {
                LogManager.GetCurrentClassLogger().Info($"Got user: {user.Name} from list");
            }
            return deserializedCollection; 
        }

        public static List<User> GetDeserializedCollectionFromFile<T>(string file)
        {
            List<User> deserializedCollectionFromFile = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(file));
            foreach (var user in deserializedCollectionFromFile)
            {
                LogManager.GetCurrentClassLogger().Info($"Got user: {user.Name} from file");
            }
            return deserializedCollectionFromFile;
        }

        public static User GetDeserializedObject<T>(RestResponse response)
        {
            var content = response.Content;
            User deserializedObject = JsonConvert.DeserializeObject<User>(content);
            LogManager.GetCurrentClassLogger().Info($"Got content of created user by name => {deserializedObject.Name}");
            return deserializedObject;
        }
    }
}
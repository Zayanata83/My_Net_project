using NLog;
using RestSharp;
using SeleniumNUnit.Business.API.APIUtils;
using SeleniumNUnit.Business.API.Models.Response;

namespace SeleniumNUnit.Business.API
{
    public class WorkWithContent
    {
        public static bool IsUsersListContainAllDataCorrectly(List<User> actualUsers)
        {
            List<User> expectedUsers = ResponseConverter.GetDeserializedCollectionFromFile<User>("Users.json");
            return expectedUsers.All(e => actualUsers.First(a => a.Id.Equals(e.Id)).IsModelCorrect(e));
        }

        public static string GetHeaderValue(IReadOnlyCollection<HeaderParameter> headers, string key)
        {
            string headerValue = string.Empty;
            try
            {
                foreach (var header in headers)
                {
                    if (header.Name.ToString().Equals(key))
                    {
                        headerValue = header.Value.ToString();
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Unable to get header value- no reference");
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, "Unable to get header value");
            }
            return headerValue;
        }
    }
}
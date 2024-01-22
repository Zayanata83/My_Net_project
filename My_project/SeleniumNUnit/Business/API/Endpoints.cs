namespace SeleniumNUnit.Business.API
{
    public class Endpoints
    {
        public static readonly string _createUser = "https://jsonplaceholder.typicode.com/users";
        public static readonly string _getSingleUser = "https://jsonplaceholder.typicode.com/users/{id}";
        public static readonly string _getKistOfUsers = "https://jsonplaceholder.typicode.com/users";
        public static readonly string _updateUser = "https://jsonplaceholder.typicode.com/users/{id}";
        public static readonly string _deleteUser = "https://jsonplaceholder.typicode.com/users/{id}";
        public static readonly string _invalidEndpoint = "https://jsonplaceholder.typicode.com/invalidendpoint";
    }
}
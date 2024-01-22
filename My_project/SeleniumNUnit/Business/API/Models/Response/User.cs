using NLog;

namespace SeleniumNUnit.Business.API.Models.Response
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public bool IsModelCorrect(User expectedUser)
        {
            return (Id.Equals(expectedUser.Id)
                    && Name.Equals(expectedUser.Name)
                    && Username.Equals(expectedUser.Username)
                    && Email.Equals(expectedUser.Email)
                    && Address.Street.Equals(expectedUser.Address.Street)
                    && Phone.Equals(expectedUser.Phone)
                    && Website.Equals(expectedUser.Website)
                    && Company.Name.Equals(expectedUser.Company.Name));     
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
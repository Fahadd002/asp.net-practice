using dependency_injection.Interface;

namespace dependency_injection.Codes
{
    public class Membership : IMembership
    {
        private readonly string _connectionString;

        public Membership(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CreateUserAccount(string name, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

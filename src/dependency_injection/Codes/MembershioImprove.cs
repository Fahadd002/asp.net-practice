using dependency_injection.Interface;

namespace dependency_injection.Codes
{
    public class MembershipImprove : IMembership
    {
        private readonly string _name;
        private readonly string _email;
        private readonly string _password;

        public MembershipImprove(string name, string email, string password) 
        { 
            _name = name;
            _email = email;
            _password = password;
        }
        public bool CreateUserAccount(string name, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

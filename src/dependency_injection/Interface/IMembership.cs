namespace dependency_injection.Interface
{
    public interface IMembership
    {
        bool CreateUserAccount(string name, string email, string password);
    }
}

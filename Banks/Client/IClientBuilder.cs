namespace Banks
{
    public interface IClientBuilder
    {
        ClientBuilder SetNameSurname(string name, string surname);
        ClientBuilder SetPassword(string password);
        ClientBuilder SetPasport(string pasport);
        Client GetClient();
    }
}
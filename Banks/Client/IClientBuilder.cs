namespace Banks
{
    public interface IClientBuilder
    {
        void Reset();
        void BuildClient(string name, string password, string surname);
        void BuildPasport(string pasport);
        Client GetClient();
    }
}
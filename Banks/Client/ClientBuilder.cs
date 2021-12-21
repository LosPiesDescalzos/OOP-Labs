using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Banks
{
    public class ClientBuilder : IClientBuilder
    {
        private string _name;
        private string _password;
        private string _surname;
        private string _pasport = null;
        public ClientBuilder SetNameSurname(string name, string surname)
        {
            _name = name;
            _surname = surname;
            return this;
        }

        public ClientBuilder SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public ClientBuilder SetPasport(string pasport)
        {
            _pasport = pasport;
            return this;
        }

        public Client GetClient()
        {
            return new Client(_name, _password, _surname, _pasport);
        }
    }
}
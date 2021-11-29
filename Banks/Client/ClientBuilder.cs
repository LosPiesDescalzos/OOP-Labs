using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Banks
{
    public class ClientBuilder : IClientBuilder
    {
        private Client _client = new Client();

        public ClientBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._client = new Client();
        }

        public void BuildClient(string name, string password, string surname)
        {
            _client.Name = name;
            _client.Surname = surname;
            _client.Password = password;
        }

        public void BuildPasport(string pasport)
        {
            _client.Pasport = pasport;
            if (pasport != null)
            {
                _client.Status = "good";
            }
        }

        public Client GetClient()
        {
            Client result = this._client;
            this.Reset();
            return result;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Banks
{
    public class Client
    {
        private int _id = 1;
        public Client(string name, string password, string surname, string pasport)
        {
            Name = name;
            Password = password;
            Surname = surname;
            Pasport = pasport;
            Status = SetStatus();
            Id = _id++;
        }

        public int Id { get; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Pasport { get; set; }
        public bool Status { get; set; }
        public List<Account> Accounts { get; } = new List<Account>();
        public List<string> Messages { get; } = new List<string>();

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public bool SetStatus()
        {
            bool status = true;
            if (Pasport == null)
            {
                status = false;
            }

            return status;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Banks
{
    public class Client
    {
        private int _id = 1;
        public Client()
        {
            Name = null;
            Password = null;
            Surname = null;
            Pasport = null;
            Status = "bad";
            Id = _id++;
        }

        public int Id { get; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Pasport { get; set; }
        public string Status { get; set; }
        public List<Account> Accounts { get; } = new List<Account>();
        public List<string> Messages { get; } = new List<string>();

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
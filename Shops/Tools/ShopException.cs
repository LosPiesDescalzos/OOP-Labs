using System;
using Shops;

namespace Shops.Tools
{
    public class ShopException : Exception
    {
        public ShopException()
        {
        }

        public ShopException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public ShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
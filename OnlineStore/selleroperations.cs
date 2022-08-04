
using System.Collections.Generic;

namespace OnlineStore
 
{
    class selleroperations
    {
        public static List<seller> mySellers = new List<seller>();

        public static void showsellerList()
        {
            foreach (seller s in mySellers)
            {
                System.Console.WriteLine($"ID: {s.ID} , Name:{s.Name}, Balance: {s.Balance}, Email: {s.Email}, password: {s.Password}");
            }
        }

        public static void removeSeller(seller s)
        {
            //foreach (seller i in mySellers)
             mySellers.Remove(s);

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    abstract class User
    {

        private static int id = 0;

        public static int idIncrement()
        {
            return ++id;
        }

        public int ID { get { return id; } set { id = value; } }

        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public abstract void read();
        public abstract void updateName(string Name);
        public abstract void updateBalance(decimal Balance);


    }

    
        
}

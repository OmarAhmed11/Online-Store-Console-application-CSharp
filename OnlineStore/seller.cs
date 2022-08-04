using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    class seller : User
    {
        public seller() 
        {
        }
        public seller(string name) : this(name, 0 , null , "0000")
        {
         
        }
        public seller(string name, decimal balance) : this(name, balance , null , "0000")
        {
        
        }
        public seller(string name, decimal balance , string email) : this(name, balance , email , "0000")
        {
            

        }
        public seller(string name, decimal balance, string email, string password)
        {
            Name = name;
            Balance = balance;
            Email = email;
            Password = password;
            selleroperations.mySellers.Add(this);
        }

        // read 
        public override string ToString()
        {
            return $"Name:{this.Name}, Balance:{this.Balance}, Email:{this.Email}, Password:{this.Password}";
        }
        public override void read()
        {
            Console.WriteLine($"Name: {this.Name}");
        }
        // update

        public override void updateName(string name)
        {
            this.Name = name;
        }
        public override void updateBalance(decimal balance)
        {
            this.Balance += balance;
        }

        


        // Items operations

        public List<Item> ShopItem = new List<Item>();
        public void addToShop(Item item)
        {
            ShopItem.Add(item);
        }

        public void deleteItem(Item item)
        {
            ShopItem.Remove(item);
        }
        public void ShowList()
        {
            if(ShopItem.Count > 0)
            {
                foreach(Item i in ShopItem)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}

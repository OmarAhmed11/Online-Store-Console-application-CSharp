using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    class Customer : User
    {

        public Customer(decimal balance)
        {
            ID = idIncrement();
            Name = "Current Online Customer";
            Balance = balance;
        }
       
        public bool bought = false;

        public List<Item> Cart = new List<Item>();
        List<Item> boughtItems = new List<Item>();

        //customer
        public override void read()
        {
            Console.WriteLine($"customer:{this.Name} \n  Balance = {this.Balance} ");
        }

        public override void updateName(string name)
        {
            this.Name = name;
        }
        public override void updateBalance(decimal balance)
        {
            this.Balance = balance;
        }

       

        //cart
        public void addToCart(Item item)
        {
            Cart.Add(item);
        }
        public void removeFromCart(Item item)
        {
            Cart.Remove(item);
        }
        public void showCartItems()
        {
            foreach (Item item in Cart)
                Console.WriteLine(item.ToString());
        }

        //bought items
        public void addToBoughtItems(Item item)
        {
            if (bought == true) // true
                boughtItems.Add(item);
        }

        public void showBoughtItems()
        {
            foreach (Item item in boughtItems)
                Console.WriteLine(item);
        }

    }
}


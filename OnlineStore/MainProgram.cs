using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class MainProgram
    {
        static void AddSellers()
        {
            seller s1 = new seller("MobileShop", 500, "mobile@gmail.com", "mob455");
            Item MobileF60 = new Item("MobileF60", 5000, "Phones", s1);
            Item MobileX44 = new Item("MobileX44", 2500, "Phones", s1);
            Item MobileHuawei6 = new Item("MobileHuawei6", 10000, "Phones", s1);
            Item HeadPhoneX70 = new Item("MobileF60", 5000, "MobileAccessories", s1);
            Item CoverY6 = new Item("MobileF60", 5000, "MobileAccessories", s1);
            Item ChargerOppoF5 = new Item("ChargerOppoF5", 500, "MobileAccessories", s1);
            s1.addToShop(MobileF60);
            s1.addToShop(MobileX44);
            s1.addToShop(MobileHuawei6);
            s1.addToShop(HeadPhoneX70);
            s1.addToShop(CoverY6);
            s1.addToShop(ChargerOppoF5);
            seller s2 = new seller("ComputerShop", 800, "computer@gmail.com", "comp455");
            Item LenovoGaming = new Item("Lenovo Gaming5", 25000, "Computers", s2);
            Item LenovoIdeapad = new Item("Lenovo Ideapad 10", 20000, "Computers", s2);
            Item Dell2 = new Item("Dell", 10000, "Computers", s2);
            Item HP = new Item("HP", 30000, "Computers", s2);
            Item keyboard1 = new Item("Wireless Keyboard", 500, "ComputerAccessories", s2);
            Item mouse1 = new Item("Wireless Mouse", 100, "ComputerAccessories", s2);
            s2.addToShop(LenovoGaming);
            s2.addToShop(LenovoIdeapad);
            s2.addToShop(Dell2);
            s2.addToShop(HP);
            s2.addToShop(keyboard1);
            s2.addToShop(mouse1);
            seller s3 = new seller("FoodShop", 1000, "food@gmail.com", "food455");
            Item ChickenBaneh = new Item("AtyabBaneh", 70, "Food", s3);
            Item Beef = new Item("AtyabBeefGrill", 100, "Food", s3);
            Item Fries = new Item("FriskesFries", 50, "Food", s3);
            Item pepsi = new Item("Pepsi", 5, "Drinks", s3);
            Item guhyna = new Item("Guhyna Mango", 7, "Drinks", s3);
            Item Potato = new Item("Potato 1 kilo", 10, "Food", s3);
            s3.addToShop(ChickenBaneh);
            s3.addToShop(Beef);
            s3.addToShop(Fries);
            s3.addToShop(pepsi);
            s3.addToShop(guhyna);
            s3.addToShop(Potato);
        }
        static void Main()
        {
            AddSellers();
            Customer CurrentCustomer = new Customer(500);
            restartapp:
            Console.WriteLine("************** Online Store ************\n");
            Console.WriteLine("Please Choose an option:\n" +
               "1 - Browse Our Sellers for Shopping \n" +
               "2 - Show all items \n" +
               "3 - Search for items by category \n" +
               "4 - Register as a new Seller to Our Store \n" +
               "5 - See Your Cart \n " +
               "6 - See your bought items \n" +
               "7 - Add Cash to your Balance \n" +
               "8 - Edit Your info as a Seller \n"+
               "9 - Exit");
            int option;
            bool ValidOption = int.TryParse(Console.ReadLine(), out option);
            if (ValidOption && (option >= 1) && (option <= 9))
            {
                MainPageOptions UserOption = (MainPageOptions)option;
                switch (UserOption)
                {
                    case (MainPageOptions.ShowAllSellers):
                        {
                        SellerNames: Console.WriteLine("Enter Seller name from below to see their items: or enter 0 to go back to main menu");
                            seller current;
                            foreach (seller s in selleroperations.mySellers)
                                s.read();
                            string ChosenName = Console.ReadLine();
                            int FoundSellerFlag = 0;
                            if (ChosenName != "0")
                            {
                                foreach (seller s in selleroperations.mySellers)
                                {
                                    if (s.Name == ChosenName)
                                    {
                                    ItemsShow:
                                        Console.WriteLine("****Here's our items*******");
                                        s.ShowList();
                                        FoundSellerFlag = 1;
                                        current = s;
                                        Console.WriteLine("Enter item name to add to your cart or 0 to go back....");
                                        string ChosenItem = Console.ReadLine();
                                        int FoundItemFlag = 0;
                                        if (ChosenItem != "0")
                                        {
                                            foreach (Item item in current.ShopItem)
                                            {
                                                if (item.Name == ChosenItem)
                                                {   
                                                    CurrentCustomer.addToCart(item);
                                                    Console.WriteLine("$$$$ Your item was added Successfully :) #####");
                                                    FoundItemFlag = 1;
                                                    goto ItemsShow;
                                                }
                                               
                                            }
                                            if (FoundItemFlag == 0)
                                            {
                                                Console.WriteLine("****Not Valid Item Name*********");
                                                goto ItemsShow;
                                            }
                                        }
                                        break;
                                    }

                                }
                                if (FoundSellerFlag == 0)
                                {
                                    Console.WriteLine("Not Valid Seller Name");
                                    goto SellerNames;
                                }
                                else
                                    goto restartapp;
                            }
                            break;
                        }
                    case (MainPageOptions.SeeCart):
                        {
                        ShowCustomerCart:    Console.WriteLine("** This is your Cart ** \n " +
                                "Select 1 to buy this item \n " + "" +
                                "or 2 to delete this item from the cart \n"
                                + "or 0 to go back to main menu");
                            CurrentCustomer.showCartItems();
                            int CartOption;
                            bool ValidCartOption = int.TryParse(Console.ReadLine(), out CartOption);
                            if(ValidCartOption && CartOption<3 && CartOption >=0)
                            {
                                switch(CartOption)
                                {
                                    case (1):
                                        {
                                            Console.WriteLine("Enter item name: ");
                                            string BuyName = Console.ReadLine();
                                            int FoundFlag = 0;
                                            foreach (Item item in CurrentCustomer.Cart)
                                            {
                                                if (BuyName == item.Name)
                                                {
                                                    FoundFlag = 1;
                                                    if (CurrentCustomer.Balance >= item.Price)
                                                    {
                                                        CurrentCustomer.Balance -= item.Price;
                                                        CurrentCustomer.bought = true;
                                                        CurrentCustomer.addToBoughtItems(item);
                                                        CurrentCustomer.bought = false;
                                                        Console.WriteLine("*** Your Item was bought successfully ***");
                                                        CurrentCustomer.removeFromCart(item);
                                                        goto ShowCustomerCart;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("*** Sorry yo don`t have enough balance ***");
                                                        goto ShowCustomerCart;
                                                    }
                                                    break;
                                                }
                                            }
                                            if (FoundFlag == 0)
                                            {
                                                Console.WriteLine("*** Please Enter a Valid Item Name ***");
                                                goto ShowCustomerCart;
                                            }
                                        }
                                        break;
                                    case (2):
                                        {
                                            Console.WriteLine("Enter item name: ");
                                            string RemoveName = Console.ReadLine();
                                            int FoundFlag = 0;
                                            foreach (Item item in CurrentCustomer.Cart)
                                            {
                                                if (RemoveName == item.Name)
                                                {
                                                    FoundFlag = 1;
                                                    CurrentCustomer.removeFromCart(item);
                                                    goto ShowCustomerCart;
                                                }
                                            }
                                            if (FoundFlag == 0)
                                            {
                                                Console.WriteLine("*** Please Enter a Valid Item Name ***");
                                                goto ShowCustomerCart;
                                            }

                                        }
                                        break;
                                    case (0):
                                        {
                                            goto restartapp;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please Enter a valid option");
                                goto restartapp;
                            }
                        }
                        break;
                    case (MainPageOptions.SeeBoughtItems):
                        {
                            Console.WriteLine("*** Here's a list of your Bought Items ***");
                            CurrentCustomer.showBoughtItems();
                            Console.WriteLine("*** Press any Key to go to Main Menu ***");
                            Console.ReadLine();
                            goto restartapp;
                        }
                        break;
                    case (MainPageOptions.AddCash):
                        {
                        UpdateBalance:    Console.WriteLine("*** Your Current Balance is {0} please enter the amount you want to add or 0 to go to main menu ***", CurrentCustomer.Balance);
                            decimal amount;
                            bool ValidAmount = decimal.TryParse(Console.ReadLine(), out amount);
                            if (ValidAmount)
                            {
                                if (amount == 0)
                                    goto restartapp;
                                else
                                {
                                    CurrentCustomer.updateBalance(amount);
                                    Console.WriteLine("*** Your Balance Was Updated Successfully ***");
                                    CurrentCustomer.read();
                                    goto restartapp;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid amount");
                                goto UpdateBalance;
                            }
                        }
                        break;
                    case (MainPageOptions.SearchByCategory):
                        {
                        searchByCategory:
                            //Display categorys 
                            List<string> categories = new List<string>();
                            var sellers = selleroperations.mySellers;
                            foreach (var s in sellers)
                            {
                                foreach (var i in s.ShopItem)
                                {
                                    if (!categories.Contains(i.Category))
                                        categories.Add(i.Category);
                                }
                            }
                            foreach (var c in categories)
                                Console.Write("|" + c.ToString() + "\t");

                            Console.WriteLine("\n enter category:\n return to main menu:(0)");

                            string category = Console.ReadLine();
                            if (category == "0")
                                goto restartapp;
                            if (!categories.Contains(category))
                            {
                                Console.WriteLine(" *** Enter a valid Category ***");
                                goto searchByCategory;
                            }


                            Console.WriteLine();
                            foreach (var s in sellers)
                            {
                                foreach (var i in s.ShopItem)
                                {
                                    if (category == i.Category)
                                        Console.WriteLine($"[item:{i.Name} \n Category:{i.Category}\n price:{i.Price}]\n");
                                }
                            }

                            Console.WriteLine("\n enter item name to add it to your cart:\n" +
                                "go back:(1)\n" +
                                "return to main menu:(0)");
                            string itemName = Console.ReadLine();

                            if (itemName == "0")
                                goto restartapp;
                            else if (itemName == "1")
                                goto searchByCategory;
                            foreach (var s in sellers)
                            {
                                foreach (var i in s.ShopItem)
                                {
                                    if (itemName == i.Name)
                                    {
                                        CurrentCustomer.addToCart(i);
                                        Console.WriteLine("Congratulations, the item has been successfully added\n");
                                        break;
                                    }
                                }
                            }
                            goto searchByCategory;
                            break;
                        }

                    case (MainPageOptions.RegisterSeller):
                        {
                            Console.WriteLine("Enter Your Store Name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter your Email");
                            var email = Console.ReadLine();
                        pass:
                            Console.WriteLine("Enter Unique Password");
                            var password = Console.ReadLine();
                            Console.WriteLine("Repeat your Password");
                            var temp = Console.ReadLine();
                            if (temp != password)
                            {
                                goto pass;
                            }
                            Console.WriteLine("Enter Current Balance");
                            var balance = decimal.Parse(Console.ReadLine());
                            var seller = new seller(name, balance, email ,password);
                            Console.WriteLine("Register Successfully");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine($"Welcome {seller.Name} to Our Site");
                        SellerInfo: Console.WriteLine(seller.ToString());
                            Console.WriteLine("Please Enter items to your store \n " +
                                "1 to add item \n " +
                                "0 to go to main menu");
                            string SellerOption = Console.ReadLine();
                            if (SellerOption == "0")
                            {
                                goto restartapp;
                            }
                            else if(SellerOption == "1")
                            {
                                Console.WriteLine("Item name: ");
                                string ItemName = Console.ReadLine();
                                Console.WriteLine("Item price: ");
                                decimal ItemPrice = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Item Category: ");
                                string ItemCategory = Console.ReadLine();
                                Item item = new Item(ItemName, ItemPrice, ItemCategory, seller);
                                seller.addToShop(item);
                                Console.WriteLine("*** Your item was added to your store successfully ***");
                                goto SellerInfo;
                            }
                            else if (SellerOption == "0")
                            {
                                goto restartapp;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter a valid Option");
                                goto SellerInfo;
                            }
                            
                        }
                       
         
                    case (MainPageOptions.ShowAllItems):
                        {
                        ItemsShow:
                            foreach (seller s in selleroperations.mySellers)
                            {
                                s.ShowList();
                            }
                            Console.WriteLine("Enter item name to add to your cart or 0 to go back....");
                            string ChosenItem = Console.ReadLine();
                            int FoundItemFlag = 0;
                            if (ChosenItem == "0")
                            {
                                goto restartapp;
                            }
                            foreach (seller s in selleroperations.mySellers)
                            {
                                foreach (Item i in s.ShopItem)
                                {
                                    if (ChosenItem == i.Name)
                                    {
                                        CurrentCustomer.addToCart(i);
                                        Console.WriteLine("$$$$ Your item was added Successfully :) #####");
                                        FoundItemFlag = 1;
                                        goto ItemsShow;
                                    }
                                }
                            }
                            if (FoundItemFlag == 0)
                            {
                                Console.WriteLine("*Not Valid Item Name****");
                                goto ItemsShow;
                            }

                        }
                        break;
                    case (MainPageOptions.EditSeller):
                        {
                        EditSeller:    Console.WriteLine("Enter your name : \n or 0 to go back");
                            string name = Console.ReadLine();
                            int SellerFound = 0;
                            if (name == "0")
                                goto restartapp;
                            else
                            {
                                foreach (seller s in selleroperations.mySellers)
                                {
                                    if (name == s.Name)
                                    {
                                        SellerFound = 1;
                                        Console.WriteLine("Enter your email: ");
                                        string email = Console.ReadLine();
                                        Console.WriteLine("Enter your Password: ");
                                        string password = Console.ReadLine();
                                        if (s.Email == email && s.Password == password)
                                        {
                                            Console.WriteLine("Enter 1 to add items to your store \n" +
                                                "2 to add balance \n 3 to edit your name \n 0 to main menu");
                                            string SellerOption = Console.ReadLine();
                                            if (SellerOption == "0")
                                                goto restartapp;
                                            else if (SellerOption == "1")
                                            {
                                             SellerAddItem:   Console.WriteLine("Item name: ");
                                                string ItemName = Console.ReadLine();
                                                Console.WriteLine("Item price: ");
                                                decimal ItemPrice = decimal.Parse(Console.ReadLine());
                                                Console.WriteLine("Item Category: ");
                                                string ItemCategory = Console.ReadLine();
                                                Item item = new Item(ItemName, ItemPrice, ItemCategory, s);
                                                s.addToShop(item);
                                                Console.WriteLine("*** Your item was added to your store successfully ***");
                                                Console.WriteLine(s.ToString());
                                                Console.WriteLine("Do you want to edit something else? Y / N ");
                                                string o = Console.ReadLine();
                                                if (o == "Y" || o == "y")
                                                    goto SellerAddItem;
                                                else
                                                    goto restartapp;
                                            }
                                            else if (SellerOption == "2")
                                            {
                                                Console.WriteLine("Please enter amount:");
                                                decimal amount = decimal.Parse(Console.ReadLine());
                                                s.Balance += amount;
                                                Console.WriteLine("*** Your Balance was added successfully *** \n " + s.ToString());
                                                goto EditSeller;
                                            }
                                            else if (SellerOption == "3")
                                            {
                                                Console.WriteLine("Enter the new name: ");
                                                string NewName = Console.ReadLine();
                                                s.Name = NewName;
                                                Console.WriteLine("*** Your Name was changed successfully *** \n " + s.ToString());
                                                goto EditSeller;
                                            }
                                           else
                                            {
                                                Console.WriteLine("Please enter a valid option");
                                                goto EditSeller;
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Please Enter valid email and password");
                                            goto EditSeller;
                                        }
                                    }
                                }
                                if(SellerFound == 0)
                                {
                                    Console.WriteLine("no such seller name");
                                    goto EditSeller;
                                }
                            }
                        }
                        break;
                    case (MainPageOptions.Exit):
                        {
                            Console.WriteLine("*** Thank You For using our Store ***" +
                                "*** Hope to see you again soon :)) ***");

                            return;
                        }

                }
            }
        }
    }
}

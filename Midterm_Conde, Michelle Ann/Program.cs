using System;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static public void Main()
    {
        //variables
        int counter = 0;
        string oAns;
        string qAns; //for all questions
        Stack orderList = new Stack();
        Queue queue = new Queue();
        string[] meals = { "Burger", "Fries", "Chicken Nuggets" };
        string[] beverages = { "Coke", "Sprite", "Iced Tea" };

        //prices
        int Burger = 50;
        int Fries = 40;
        int Chicken_Nuggets = 150;
        int Coke = 25;
        int Sprite = 25;
        int Iced_Tea = 30;

        int total = 0;

        //welcome to McDo
        Start:
        Console.WriteLine("================================");
        Console.WriteLine("Welcome to MgRonald! \nLove mo ko!");
        Console.WriteLine("================================");
        Console.ReadLine();

        do
        {
            //transaction menu
            Console.Write("Select transaction -> \t [1] Get Queue Number\n\t\t\t [2] Order\n\t\t\t [3] Checkout\nTransaction: ");
            int tAns = int.Parse(Console.ReadLine());

            switch(tAns)
            {
                case 1:
                    counter++;
                    queue.Enqueue(counter);
                    //get queue number implement queue
                    Console.WriteLine("Your Queue Number: " + counter);

                    Console.Write("Proceed to order? Y/N: ");
                    qAns = Console.ReadLine().ToUpper();
                    if (qAns == "Y") { goto case 2; } else { break; }

                case 2:
                    //conditions
                    if(queue.Count == 0)
                    {
                        Console.WriteLine("Please get a queue number first before ordering.");
                        break;
                    }

                    //ordering meal
                    Console.WriteLine("================================\nHere's the menu for our meals:\nPlease enter the name of the item you want to order");
                    int mIndex = 0;
                    for (int i = 0; mIndex < meals.Length; i++)
                    {
                        Console.WriteLine($"[{mIndex + 1}] {meals[i]}");
                        mIndex++;
                    }
                    Console.WriteLine("================================\nPrices will be reflected at checkout\nPlease type 'X' when you want to exit this menu.");
                    
                    //adding items into the stack for checkout
                    string custOrder;
                    do
                    {
                        custOrder = Console.ReadLine();
                        if (custOrder == "X")
                            break;
                        if (meals.Contains(custOrder))
                        {
                            orderList.Push(custOrder);
                            Console.WriteLine("Added to cart.");
                        } else
                        {
                            Console.WriteLine("That item is not on the menu. Please try again");
                        }
                    } while (custOrder != "X");
                    
                    //beverages
                    Console.WriteLine("================================\nHere's the menu for our beverages:\nPlease enter the name of the item you want to order.");
                    Console.WriteLine("Beverages:");

                    int bIndex = 0;
                    for (int i = 0; bIndex < beverages.Length; i++)
                    {
                        Console.WriteLine($"[{bIndex + 1}] {beverages[i]}");
                        bIndex++;
                    }
                    Console.WriteLine("================================\nPrices will be reflected at checkout\nPlease type 'X' when you want to exit this menu.");

                    //adding to stack
                    do
                    {
                        custOrder = Console.ReadLine();
                        if (custOrder == "X")
                            break;
                        if (beverages.Contains(custOrder))
                        {
                            orderList.Push(custOrder);
                            Console.WriteLine("Added to cart.");
                        }
                        else
                        {
                            Console.WriteLine("That item is not on the menu. Please try again");
                        }
                    } while (custOrder != "X");
                    //end of case 2 gi commentan kay buta ko

                    Console.Write("Proceed to checkout? Y/N: ");
                    qAns = Console.ReadLine().ToUpper();
                    if (qAns == "Y") { goto case 3; } else { break; }

                case 3:
                    //checking conditions
                    if (queue.Count == 0)
                    {
                        Console.WriteLine("Please get a queue number first before ordering.");
                        break;
                    }
                    if (orderList.Count == 0)
                    {
                        Console.WriteLine("Cart is empty. Do you want to order?");
                        string cAns = Console.ReadLine();
                        if (cAns == "y")
                        {
                            goto case 2;
                        }
                    }

                    List<string> fOrderList = new List<string>();
                    Console.WriteLine("Processing your order...");
                    Console.WriteLine($"Order No. [{queue.Peek()}]");
                    foreach(string i in orderList)
                    {
                        fOrderList.Add(i);
                        Console.WriteLine(i);
                    }

                    do
                    {
                        Console.Write("Do you have any changes to your order? Y/N: ");
                        qAns = Console.ReadLine().ToUpper();
                        if (qAns == "Y")
                        {
                            Console.Write("Remove or Add items? ");
                            qAns = Console.ReadLine();
                            if (qAns == "Remove")
                            {
                                do
                                {
                                    Console.Write("Please enter the item you want to remove: ");
                                    qAns = Console.ReadLine();
                                    if (qAns == "X") { break; }
                                    if (fOrderList.Contains(qAns))
                                    {
                                        fOrderList.Remove(qAns);
                                        Console.WriteLine("Removed from cart.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("That item is not on your cart. Please try again");
                                    }

                                } while (qAns != "X");
                            }
                            else if (qAns == "Add")
                            {
                                do
                                {
                                    Console.Write("Please enter the item you want to add: ");
                                    qAns = Console.ReadLine();
                                    if (qAns == "X") { break; }
                                    if (meals.Contains(qAns) || beverages.Contains(qAns))
                                    {
                                        fOrderList.Add(qAns);
                                        Console.WriteLine("Added to cart.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("That item is not on the menu. Please try again");
                                    }
                                } while (qAns != "X");
                            }
                        }
                    } while (qAns != "N");

                    Console.WriteLine("Processing your order...");
                    Console.WriteLine($"Order No. [{queue.Peek()}]");
                    foreach (string i in fOrderList)
                    {
                        Console.WriteLine(i);
                        if (i == "Burger")
                        {
                            total = total + Burger;
                        }
                        if (i == "Fries")
                        {
                            total = total + Fries;
                        }
                        if (i == "Chicken Nuggets")
                        {
                            total = total + Chicken_Nuggets;
                        }
                        if (i == "Coke")
                        {
                            total = total + Coke;
                        }
                        if (i == "Sprite")
                        {
                            total = total + Sprite;
                        }
                        if (i == "Iced Tea")
                        {
                            total = total + Iced_Tea;
                        }
                    }
                    Console.WriteLine("Here is your total: Php " + total);

                    //if N
                    Console.WriteLine("Thank you for shopping at MgRonald! Enjoy your day!");
                    queue.Dequeue();
                    fOrderList.Clear();
                    orderList.Clear();
                    if(queue.Count != 0)
                    {
                        Console.WriteLine($"Order No. [{queue.Peek()}]");
                        goto case 2;
                    }
                    break;
                    Console.Clear();
                    goto Start;
            }
            //end
            Console.Write("Continue transaction? Y/N: ");
            oAns = Console.ReadLine().ToUpper();
        } while (oAns != "N");
    }
}
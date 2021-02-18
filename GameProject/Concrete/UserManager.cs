using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    public class UserManager : BaseUserManager
    {
        private IUserCheckService _userCheckService;

        public UserManager(IUserCheckService userCheckService)
        {
            _userCheckService = userCheckService;
        }

        public override bool CheckUser(string FirstName, string LastName, string NationalityId, string YearOfBirth)
        {
            if (_userCheckService.CheckIfRealPerson(FirstName, LastName, NationalityId, YearOfBirth))
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        public override List<User> Delete(List<User> users, int UserIndex)
        {
            users.RemoveAt(UserIndex);
            return users;
        }

        public override int GetUser(List<User> users, string UserId)
        {
            int Index = -1;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].NationalityId == UserId)
                {
                    Index = i;
                }
            }
            return Index;
        }

        public override List<User> AddOrder(List<User> users, string UserId, string OrderId, Game game)
        {
            if (users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].NationalityId == UserId)
                    {
                        for (int j = 0; j < users[i].Orders.Count; j++)
                        {
                            if (users[i].Orders[j].Id == OrderId)
                            {
                                users[i].Orders[j].Games.Add(game);
                                Console.WriteLine("\nOrder Successfully Completed.");
                            }
                        }                       
                    }
                    else
                    {
                        Console.WriteLine("\nNo User With This Id.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo User found.");
            }
            return users;
        }
        public override void PrintUser(List<User> users)
        {
            foreach (var user in users)
            {
                if (users.Count > 0)
                {
                    Console.WriteLine("\nViewing All Users...\n");
                    Console.WriteLine("First Name: " + user.FirstName);
                    Console.WriteLine("Last Name: " + user.LastName);
                    Console.WriteLine("Nationality Id: " + user.NationalityId);
                    Console.WriteLine("Year Of Birth: " + user.YearOfBirth);
                    Console.WriteLine("Orders:");

                    if (user.Orders.Count > 0)
                    {
                        string AllOrders = "";
                        for (int i = 0; i < user.Orders.Count; i++)
                        {
                            for (int j = 0; j < user.Orders[i].Games.Count; j++)
                            {
                                var game = user.Orders[i].Games[j];
                                AllOrders += "Order Id: " + user.Orders[i].Id + ", " + "Game Name: " + game.Name + ", " + "Game Price: " + game.Price + "TL" + ", ";

                                if (game.Campaigns.Count > 0)
                                {
                                    for (int k = 0; k < game.Campaigns.Count; k++)
                                    {
                                        var campaign = game.Campaigns[k];
                                        if (k == game.Campaigns.Count - 1)
                                        {
                                            AllOrders += "Campaign Name: " + campaign.Name + ", " + "Discount Rate: " + campaign.DiscountRate + "\n";
                                        }
                                        else
                                        {
                                            AllOrders += "Campaign Name: " + campaign.Name + ", " + "Discount Rate: " + campaign.DiscountRate + ", ";
                                        }
                                    }
                                }
                                else
                                {
                                    AllOrders += "Campaigns: " + "No Campaign\n";
                                }
                            }
                        }
                        Console.WriteLine(AllOrders);
                    }
                    else
                    {
                        Console.WriteLine("\nNo Order Found.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo User Found.");
                }
            }
        }
    }
}

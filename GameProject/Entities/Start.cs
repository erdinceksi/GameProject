using GameProject.Abstract;
using GameProject.Adapters;
using GameProject.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Entities
{
    public class Start
    {
        public void Menu()
        {
            BaseUserManager baseUserManager = new UserManager(new MernisServiceAdapter());
            BaseGameManager baseGameManager = new GameManager();
            BaseCampaignManager baseCampaignManager = new CampaignManager();
            BaseOrderManager baseOrderManager = new OrderManager();

            List<User> users = new List<User>();
            List<Campaign> campaigns = new List<Campaign>();
            List<Game> games = new List<Game>();

            Game gameOne = new Game("1", "Battlefield 4", 94);
            games.Add(gameOne);
            Game gameTwo = new Game("2", "Catan Universe", 0);
            games.Add(gameTwo);
            Game gameThree = new Game("3", "Cs-Go", 30);
            games.Add(gameThree);

            bool Exit = false;
            string Option;
            string Name, LastName, NationalityId, YearOfBirth;
            string CampaignId, CampaignName, CampaignDiscountRate;
            int UserIndex, GameIndex, OrderIndex, CampaignIndex;
            string GameId, OrderId, ShipCity, ShipCountry;

            while (!Exit)
            {
                Console.WriteLine("\nMain Menu\n");
                Console.WriteLine("1. User Operations");
                Console.WriteLine("2. Campaign Operations");
                Console.WriteLine("3. Order Operations");
                Console.WriteLine("4. Exit\n");
                Console.Write("Option: ");
                Option = Console.ReadLine();
                Console.Clear();
                if (String.IsNullOrEmpty(Option))
                {
                    Console.WriteLine("\nPlease Enter a Valid Option.");
                }
                switch (Option)
                {
                    case "1":
                        Console.WriteLine("\n1. Register User");
                        Console.WriteLine("2. Delete User");
                        Console.WriteLine("3. Update User");
                        Console.WriteLine("4. View All Users");
                        Console.WriteLine("5. <= Back\n");
                        Console.Write("Option: ");
                        Option = Console.ReadLine();
                        Console.Clear();
                        if (String.IsNullOrEmpty(Option))
                        {
                            Console.WriteLine("\nPlease Enter a Valid Option.");

                        }
                        else if (Option == "1")
                        {
                            Console.Write("\nEnter First Name: ");
                            Name = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            LastName = Console.ReadLine();
                            Console.Write("Enter Nationality Id: ");
                            NationalityId = Console.ReadLine();
                            Console.Write("Enter Year of Birth: ");
                            YearOfBirth = Console.ReadLine();

                            while (String.IsNullOrEmpty(Name) ||
                                    String.IsNullOrEmpty(LastName) ||
                                    String.IsNullOrEmpty(NationalityId) ||
                                    String.IsNullOrEmpty(YearOfBirth) ||
                                    NationalityId.Length < 11)
                            {
                                Console.Write("\nInvalid Information.\n");
                                Console.Write("\nEnter First Name: ");
                                Name = Console.ReadLine();
                                Console.Write("Enter Last Name: ");
                                LastName = Console.ReadLine();
                                Console.Write("Enter Nationality Id: ");
                                NationalityId = Console.ReadLine();
                                Console.Write("Enter Year of Birth: ");
                                YearOfBirth = Console.ReadLine();
                            }

                            bool valid = baseUserManager.CheckUser(Name, LastName, NationalityId, YearOfBirth);
                            if (valid)
                            {
                                User user = new User(Name, LastName, NationalityId, YearOfBirth);
                                users.Add(user);
                                Console.WriteLine("\nUser " + Name + " is Registered.");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Information.");
                                break;
                            }
                            break;
                        }
                        else if (Option == "2")
                        {
                            if (users.Count > 0)
                            {
                                Console.Write("\nEnter User Nationality Id: ");
                                NationalityId = Console.ReadLine();

                                while (String.IsNullOrEmpty(NationalityId) || NationalityId.Length < 11)
                                {
                                    Console.WriteLine("\nInvalid Nationality Id.");
                                    Console.Write("\nEnter User Nationality Id: ");
                                    NationalityId = Console.ReadLine();
                                }

                                UserIndex = baseUserManager.GetUser(users, NationalityId);
                                
                                if (UserIndex == -1)
                                {
                                    Console.WriteLine("\nNo User Found With This Id.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nUser " + users[UserIndex].FirstName + " is deleted.");
                                    users = baseUserManager.Delete(users, UserIndex);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo User Found.");
                                break;
                            }
                            break;
                        }
                        else if (Option == "3")
                        {
                            if (users.Count > 0)
                            {
                                Console.Write("\nEnter User Nationality Id: ");
                                NationalityId = Console.ReadLine();

                                while (String.IsNullOrEmpty(NationalityId) || NationalityId.Length < 11)
                                {
                                    Console.WriteLine("\nInvalid Nationality Id.");
                                    Console.Write("\nEnter User Nationality Id: ");
                                    NationalityId = Console.ReadLine();
                                }

                                UserIndex = baseUserManager.GetUser(users, NationalityId);

                                if (UserIndex != -1)
                                {
                                    Console.Clear();
                                    Console.Write("\nEnter First Name: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Enter Last Name: ");
                                    LastName = Console.ReadLine();
                                    Console.Write("Enter Nationality Id: ");
                                    NationalityId = Console.ReadLine();
                                    Console.Write("Enter Year of Birth: ");
                                    YearOfBirth = Console.ReadLine();
                                    Console.Clear();

                                    while (String.IsNullOrEmpty(Name) ||
                                        String.IsNullOrEmpty(LastName) ||
                                        String.IsNullOrEmpty(NationalityId) ||
                                        String.IsNullOrEmpty(YearOfBirth) ||
                                        NationalityId.Length < 11)
                                    {
                                        Console.Write("\nInvalid Information.\n");
                                        Console.Write("Enter First Name: ");
                                        Name = Console.ReadLine();
                                        Console.Write("Enter Last Name: ");
                                        LastName = Console.ReadLine();
                                        Console.Write("Enter Nationality Id: ");
                                        NationalityId = Console.ReadLine();
                                        Console.Write("Enter Year of Birth: ");
                                        YearOfBirth = Console.ReadLine();
                                    }
                                    Console.Clear();
                                    bool valid = baseUserManager.CheckUser(Name, LastName, NationalityId, YearOfBirth);

                                    if (valid)
                                    {
                                        users[UserIndex].FirstName = Name;
                                        users[UserIndex].LastName = LastName;
                                        users[UserIndex].NationalityId = NationalityId;
                                        users[UserIndex].YearOfBirth = YearOfBirth;
                                        Console.WriteLine("\nUser Updated.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid Information.");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nNo User Found.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo User Found.");
                                break;
                            }
                            break;
                        }
                        else if (Option == "4")
                        {
                            if (users.Count > 0)
                            {
                                baseUserManager.PrintUser(users);
                            }
                            else
                            {
                                Console.WriteLine("\nNo User Found.");
                                break;
                            }
                        }
                        if (Option == "5")
                        {
                            Console.Clear();
                            break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("\n1. Register Campaign");
                        Console.WriteLine("2. Delete Campaign");
                        Console.WriteLine("3. Update Campaign");
                        Console.WriteLine("4. View All Campaigns");
                        Console.WriteLine("5. <= Back\n");
                        Console.Write("Option: ");
                        Option = Console.ReadLine();
                        Console.Clear();
                        if (String.IsNullOrEmpty(Option))
                        {
                            Console.WriteLine("\nPlease Enter a Valid Option.");
                            break;
                        }
                        else if (Option == "1")
                        {
                            Console.Write("\nEnter Campaign Id: ");
                            CampaignId = Console.ReadLine();
                            Console.Write("Enter Campaign Name: ");
                            CampaignName = Console.ReadLine();
                            Console.Write("Enter Discount Rate: ");
                            CampaignDiscountRate = Console.ReadLine();

                            if (!String.IsNullOrEmpty(CampaignId) && 
                                !String.IsNullOrEmpty(CampaignName) &&
                                !String.IsNullOrEmpty(CampaignDiscountRate))
                            {
                                CampaignIndex = baseCampaignManager.GetCampaign(campaigns, CampaignId);

                                if (CampaignIndex != -1)
                                {
                                    Console.WriteLine("\nCampaign Already Exists.");
                                    break;
                                }
                                else
                                {
                                    
                                    Campaign campaign = new Campaign(CampaignId, CampaignName, Convert.ToDecimal(CampaignDiscountRate));
                                    campaigns.Add(campaign);
                                    Console.WriteLine("\nCampaign Is Registered.");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Information.");
                            }
                        }
                        else if (Option == "2")
                        {
                            if (campaigns.Count > 0)
                            {
                                baseCampaignManager.PrintCampaigns(campaigns);
                                Console.Write("\nEnter Campaign Id: ");
                                CampaignId = Console.ReadLine();

                                while (String.IsNullOrEmpty(CampaignId))
                                {
                                    Console.WriteLine("\nInvalid Campaign Id.");
                                    Console.Write("\nEnter Campaign Id: ");
                                    CampaignId = Console.ReadLine();
                                }

                                CampaignIndex = baseCampaignManager.GetCampaign(campaigns, CampaignId);

                                if (CampaignIndex != -1)
                                {
                                    campaigns.RemoveAt(CampaignIndex);
                                    Console.WriteLine("\nCampaign Is Deleted.");
                                }
                                else
                                {
                                    Console.WriteLine("\nNo Campaign Found With This Id.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Campaign Found.");
                                break;
                            }
                        }
                        else if (Option == "3")
                        {
                            if (campaigns.Count > 0)
                            {
                                baseCampaignManager.PrintCampaigns(campaigns);

                                Console.Write("\nEnter Campaign Id: ");
                                CampaignId = Console.ReadLine();

                                while (String.IsNullOrEmpty(CampaignId))
                                {
                                    Console.WriteLine("\nInvalid Campaign Id.");
                                    Console.Write("\nEnter Campaign Id: ");
                                    CampaignId = Console.ReadLine();
                                }

                                CampaignIndex = baseCampaignManager.GetCampaign(campaigns, CampaignId);

                                if (CampaignIndex != -1)
                                {
                                    Console.Write("Enter Campaign Name: ");
                                    CampaignName = Console.ReadLine();
                                    Console.Write("Enter Discount Rate: ");
                                    CampaignDiscountRate = Console.ReadLine();
                                    Console.Clear();

                                    while (String.IsNullOrEmpty(CampaignId) ||
                                        String.IsNullOrEmpty(CampaignName) || 
                                        String.IsNullOrEmpty(CampaignDiscountRate))
                                    {
                                        Console.Write("\nInvalid Information.\n");
                                        Console.Write("\nEnter Campaign Id: ");
                                        CampaignId = Console.ReadLine();
                                        Console.Write("Enter Campaign Name: ");
                                        CampaignName = Console.ReadLine();
                                        Console.Write("Enter Discount Rate: ");
                                        CampaignDiscountRate = Console.ReadLine();
                                    }

                                    campaigns[CampaignIndex].Id = CampaignId;
                                    campaigns[CampaignIndex].Name = CampaignName;
                                    campaigns[CampaignIndex].DiscountRate = Convert.ToDecimal(CampaignDiscountRate);
                                    Console.Clear();
                                    Console.WriteLine("\nCampaign Updated.");
                                }
                                else
                                {
                                    Console.WriteLine("\nNo Campaign Found.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Campaign Found.");
                                break;
                            }
                            break;
                        }
                        else if (Option == "4")
                        {
                            if (campaigns.Count > 0)
                            {
                                baseCampaignManager.PrintCampaigns(campaigns);
                            }
                            else
                            {
                                Console.WriteLine("\nNo Campaign Found.");
                                break;
                            }
                        }
                        else if (Option == "5")
                        {
                            Console.Clear();
                            break;
                        }
                        break;
                    case "3":

                        Console.WriteLine("\n1. Order a Game");
                        Console.WriteLine("2. Register Campaign to a Game");
                        Console.WriteLine("3. <= Back\n");
                        Console.Write("Option: ");
                        Option = Console.ReadLine();
                        Console.Clear();

                        if (String.IsNullOrEmpty(Option))
                        {
                            Console.WriteLine("\nPlease Enter a Valid Option.");
                            break;
                        }
                        
                        else if (Option == "1")
                        {
                            if (users.Count > 0)
                            {
                                baseGameManager.PrintGameWithCampaigns(games);
                                Console.Write("\nEnter User Nationality Id: ");
                                NationalityId = Console.ReadLine();
                                UserIndex = baseUserManager.GetUser(users, NationalityId);

                                if (UserIndex != -1)
                                {
                                    Console.Write("Enter Order Id: ");
                                    OrderId = Console.ReadLine();
                                    OrderIndex = baseOrderManager.GetOrder(users[UserIndex].Orders, OrderId);
                                    if (OrderIndex == -1)
                                    {
                                        Console.Write("Enter Game Id: ");
                                        GameId = Console.ReadLine();
                                        GameIndex = baseGameManager.GetGame(games, GameId);
                                        if (GameIndex != -1)
                                        {
                                            Console.Write("Enter City: ");
                                            ShipCity = Console.ReadLine();
                                            Console.Write("Enter Country: ");
                                            ShipCountry = Console.ReadLine();

                                            Order order = new Order(OrderId, NationalityId, ShipCity, ShipCountry, DateTime.Now);
                                            users[UserIndex].Orders.Add(order);
                                            users = baseUserManager.AddOrder(users, NationalityId, OrderId, games[GameIndex]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nNo Game With This Id.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThis Order Already Exists In The Orders.");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nNo User With This Id.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo User Found.");
                                break;
                            }
                            break;
                        }
                        else if (Option == "2")
                        {
                            bool Found = false;
                            baseGameManager.PrintGameWithCampaigns(games);
                            baseCampaignManager.PrintCampaigns(campaigns);

                            if (campaigns.Count > 0)
                            {
                                Console.Write("\nEnter Game Id: ");
                                GameId = Console.ReadLine();
                                Console.Write("Enter Campaign Id: ");
                                CampaignId = Console.ReadLine();

                                if (!String.IsNullOrEmpty(GameId) && !String.IsNullOrEmpty(CampaignId))
                                {
                                    
                                    GameIndex = baseGameManager.GetGame(games, GameId);
                                    if (GameIndex != -1)
                                    {
                                        CampaignIndex = baseCampaignManager.GetCampaign(campaigns, CampaignId);
                                        if (CampaignIndex != -1)
                                        {
                                            var Allcampaigns = games[GameIndex].Campaigns;
                                            if (Allcampaigns.Count > 0)
                                            {
                                                for (int i = 0; i < Allcampaigns.Count; i++)
                                                {
                                                    if (Allcampaigns[i].Id == CampaignId)
                                                    {
                                                        Found = true;
                                                    }
                                                }                              
                                            }
                                            if (!Found)
                                            {
                                                games[GameIndex].Campaigns.Add(campaigns[CampaignIndex]);
                                                Console.WriteLine("\nCampaing Added to Game: " + games[GameIndex].Name);
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nThis Campaign Already Exists In This Game.");
                                                break;                                              
                                            }                                         
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nCampaign Not Foud.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nGame Not Foud.");
                                        break;
                                    }            
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Information.");
                                    break;
                                }
                            }
                            break;
                        }
                        else if (Option == "3")
                        {
                            Console.Clear();
                            break;
                        }
                        break;
                    case "4":
                        Exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

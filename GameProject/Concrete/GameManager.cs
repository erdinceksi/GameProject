using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    public class GameManager : BaseGameManager
    {
        public override int GetGame(List<Game> games, string GameId)
        {
            int Index = -1;
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Id == GameId)
                {
                    Index = i;
                }
            }
            return Index;
        }

        public override void PrintGameWithCampaigns(List<Game> games)
        {
            string campaigns = "";
            if (games.Count > 0)
            {
                Console.WriteLine("\nViewing All Games With Campaigns...\n");
                for (int i = 0; i < games.Count; i++)
                {
                    if (games[i].Campaigns.Count > 0)
                    {
                        for (int j = 0; j < games[i].Campaigns.Count; j++)
                        {
                            var gamewcampaigns = games[i].Campaigns[j];
                            if (j == games[i].Campaigns.Count - 1)
                            {
                                campaigns += gamewcampaigns.Name + ": " + "%" + gamewcampaigns.DiscountRate + " off";
                            }
                            else
                            {
                                campaigns += gamewcampaigns.Name + ": " + "%" + gamewcampaigns.DiscountRate + " off" + ", ";
                            }
                        }
                        Console.WriteLine(games[i].Id + ": " + games[i].Name + ", " + games[i].Price + "TL ," + campaigns);
                    }
                    else
                    {
                        Console.WriteLine(games[i].Id + ": " + games[i].Name + ", " + games[i].Price + "TL");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo Game Found.");
            }
        }
    }
}

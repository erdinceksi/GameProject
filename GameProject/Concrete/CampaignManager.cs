using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    public class CampaignManager : BaseCampaignManager
    {
        public override void PrintCampaigns(List<Campaign> campaigns)
        {
            if (campaigns.Count > 0)
            {
                Console.WriteLine("\nViewing All Campaigns...\n");

                foreach (var campaign in campaigns)
                {
                    Console.WriteLine("Campaign Id: " + campaign.Id);
                    Console.WriteLine("Campaign Name: " + campaign.Name);
                    Console.WriteLine("Campaign Discount Rate: " + campaign.DiscountRate);
                }
            }
            else
            {
                Console.WriteLine("\nNo Campaign Found.");
            }         
        }

        public override int GetCampaign(List<Campaign> campaigns, string CampaignId)
        {
            int Index = -1;
            for (int i = 0; i < campaigns.Count; i++)
            {
                if (campaigns[i].Id == CampaignId)
                {
                    Index = i;
                }
            }
            return Index;
        }
    }
}

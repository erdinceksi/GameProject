using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public interface ICampaignService
    {
        void PrintCampaigns(List<Campaign> campaigns);
        int GetCampaign(List<Campaign> campaigns, string CampaignId);
    }
}

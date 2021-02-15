using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public abstract class BaseCampaignManager : ICampaignService
    {
        public virtual void PrintCampaigns(List<Campaign> campaigns)
        {
            throw new NotImplementedException();
        }

        public virtual int GetCampaign(List<Campaign> campaigns, string CampaignId)
        {
            throw new NotImplementedException();
        }
    }
}

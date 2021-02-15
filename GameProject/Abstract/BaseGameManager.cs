using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public abstract class BaseGameManager : IGameService
    {
        public virtual int GetGame(List<Game> games, string GameId)
        {
            throw new NotImplementedException();
        }

        public virtual void PrintGameWithCampaigns(List<Game> games)
        {
            throw new NotImplementedException();
        }
    }
}

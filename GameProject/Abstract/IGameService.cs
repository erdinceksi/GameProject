using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    public interface IGameService
    {
        int GetGame(List<Game> games, string GameId);
        void PrintGameWithCampaigns(List<Game> games);
    }
}

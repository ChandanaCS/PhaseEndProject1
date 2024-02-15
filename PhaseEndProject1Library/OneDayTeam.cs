using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseEndProject1Library
{
    public class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();

        public int capacity;
        public OneDayTeam()
        {
            capacity = 11;
        }
        public void Add(Player player)
        {
            Player newplayer = new Player();
            newplayer.PlayerId = player.PlayerId;
            newplayer.PlayerName = player.PlayerName;
            newplayer.PlayerAge = player.PlayerAge;
            oneDayTeam.Add(newplayer);
            Console.WriteLine("Player is added successfully");
        }
        public void Remove(int playerId)
        {
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine("Player is removed successfully");
            }
            else
            {
                Console.WriteLine("\nPlayer not found for removal.");
            }
        }
        public Player GetPlayerById(int playerId)
        {
            Player playerToDisplayById = oneDayTeam.Find(p => p.PlayerId == playerId);
            return playerToDisplayById;
        }
        public Player GetPlayerByName(string playerName)
        {
            Player playerToDisplayByName = oneDayTeam.Find(p => p.PlayerName == playerName);
            return playerToDisplayByName;
        }
        public List<Player> GetAllPlayers()
        {
            return new List<Player>(oneDayTeam);
        }
    }
}

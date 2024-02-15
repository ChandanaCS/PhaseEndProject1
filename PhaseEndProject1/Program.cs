using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhaseEndProject1Library;

namespace PhaseEndProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITeam players = new OneDayTeam();
            OneDayTeam odtobj = new OneDayTeam();
            int userchoice = 0;
            string ans = "Yes";
             
            do
            {
                try
                {
                    Console.Write("Enter 1:To Add Player 2:To Remove Player by Id 3.Get Player By Id 4.Get Player by Name 5.Get All Players:");
                    userchoice = Convert.ToInt32(Console.ReadLine());
                    switch (userchoice)
                    {
                        case 1:
                            try
                            {
                                if (OneDayTeam.oneDayTeam.Count < odtobj.capacity)
                                {
                                    Player newplayer = new Player();
                                    Console.Write("Enter Player Id: ");
                                    newplayer.PlayerId = Convert.ToInt32(Console.ReadLine());
                                    int toCheckInput = 0;
                                    while (toCheckInput == 0)
                                    {
                                        Console.Write("Enter Player Name: ");
                                        string name = Console.ReadLine();
                                        if (name.All(char.IsLetter))
                                        {
                                            newplayer.PlayerName = name;
                                            toCheckInput = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter a valid name");
                                        }
                                    }
                                    Console.Write("Enter Player Age: ");
                                    newplayer.PlayerAge = Convert.ToInt32(Console.ReadLine());
                                    odtobj.Add(newplayer);
                                }
                                else
                                {
                                    Console.WriteLine("Cannot add more players since the team already contains 11 players");
                                }
                            }
                            catch(InvalidPlayerIDException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"An Exception occured: {ex.Message}");
                            }
                            break;


                        case 2:
                            try
                            {
                                if (OneDayTeam.oneDayTeam.Count == 0)
                                {
                                    Console.WriteLine("There are no players in the team");
                                }
                                else
                                {
                                    Console.Write("Enter Player Id to Remove: ");
                                    int player_id_to_remove = Convert.ToInt32(Console.ReadLine());
                                    odtobj.Remove(player_id_to_remove);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An Exception occured: {ex.Message}");
                            }
                            break;

                        case 3:
                            try
                            {
                                Console.Write("Enter Player Id: ");
                                int player_id_to_display = Convert.ToInt32(Console.ReadLine());
                                Player toGetPlayerById = new Player();
                                toGetPlayerById = odtobj.GetPlayerById(player_id_to_display);
                                if (toGetPlayerById != null)
                                {
                                    Console.WriteLine($"{player_id_to_display}\t{toGetPlayerById.PlayerName}\t{toGetPlayerById.PlayerAge}.");
                                }
                                else
                                {
                                    Console.WriteLine("No Player exist with that ID.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An Exception occured: {ex.Message}");
                            }
                            break;
                            
                       
                        case 4:
                            try
                            {
                                Console.Write("Enter Player Name: ");
                                string player_name_to_display = Console.ReadLine();
                                Player toGetPlayerByName = new Player();
                                toGetPlayerByName = odtobj.GetPlayerByName(player_name_to_display);
                                if (toGetPlayerByName != null)
                                {
                                    Console.WriteLine($"{toGetPlayerByName.PlayerId}\t{toGetPlayerByName.PlayerName}\t{toGetPlayerByName.PlayerAge}.");
                                }
                                else
                                {
                                    Console.WriteLine("No Player exist with that Name.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An Exception occured: {ex.Message}");
                            }
                            break;
                            
                  
                        case 5:
                            if (OneDayTeam.oneDayTeam.Count == 0)
                            {
                                Console.WriteLine("There are no players in the team");
                            }
                            else
                            {
                                List<Player> allPlayersInTeam = odtobj.GetAllPlayers();
                                foreach (Player player in allPlayersInTeam)
                                {
                                    Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                                }
                            }
                            break;


                        default:
                            Console.WriteLine("Enter valid number!!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write("Do u want to continue (yes/no)?: ");
                ans = Console.ReadLine();

            } while (ans == "Yes" || ans == "yes");

        }
    }
}

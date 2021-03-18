using AntiCoreCheat.SDK.Entities;
using AntiCoreCheat.SDK.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntiCoreCheat.Features
{
    class ThreadsCore
    {
        public static Thread CoreThread = new Thread(new ThreadStart(AntiCore));
        public static List<SDK.Entities.CSPlayer> PlayerList = new List<SDK.Entities.CSPlayer>();

        public static void AntiCore()
        {
            while(true)
            {
                if(Engine.GameState == SDK.Classes.Enums.GameState.FULL) // ON IN GAME
                {
                    SDK.Entities.CSLocalPlayer LocalPlayer = new SDK.Entities.CSLocalPlayer();

                    var sw = new Stopwatch();
                    sw.Start();
                    PlayerList.Clear();
                    for (int i = 0; i <= SDK.Game.Engine.MaxPlayer; i++)
                    {
                        SDK.Entities.CSPlayer Player = new SDK.Entities.CSPlayer(i);
                        if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != LocalPlayer.EntityIndex && Player.Name != LocalPlayer.Name && LocalPlayer.BaseAddress != Player.BaseAddress)
                        {
                            PlayerList.Add(Player);
                        }
                    }
                    sw.Stop();
                    Logger.LSDebug.PrintLine(string.Format("Updated Players. ({0} Players in list.) - Elapsed time: {1}ms", PlayerList.Count, sw.ElapsedMilliseconds), LSDebug.TextType.Success);
                    UpdateGrid();

                    foreach (CSPlayer player in PlayerList)
                    {
                        if(player.Team == LocalPlayer.Team)
                        {
                            player.Glow(0, 0, 255f);
                        }
                        else
                        {
                            player.Glow(255f, 0, 0f);
                        }
                    }
                }
            }
        }

        public static void UpdateGrid()
        {
            foreach (var Player in PlayerList)
            {
                Logger.LSDebug.SetVariable(Player.Name, Player.Health);
            }
            Thread.Sleep(300);
        }
    }
}

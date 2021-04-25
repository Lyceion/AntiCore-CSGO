using AntiCoreCheat.SDK.Entities;
using AntiCoreCheat.SDK.Game;
using AntiCoreCheat.SDK.Game.Offsets;
using AntiCoreCheat.SDK.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Features
{
    class ThreadsCore
    {
        public static List<CSPlayer> PlayerList = new List<CSPlayer>();
        public static CSLocalPlayer LocalPlayer = new CSLocalPlayer();
        public static void PlayerLoop()
        {
            while(true)
            {
                if (Engine.GameState == SDK.Classes.Enums.GameState.FULL)
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    PlayerList.Clear();
                    for (int i = 0; i <= Engine.MaxPlayer; i++)
                    {
                        CSPlayer Player = new CSPlayer(i);
                        if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != LocalPlayer.EntityIndex && Player.Name != LocalPlayer.Name && LocalPlayer.BaseAddress != Player.BaseAddress)
                            PlayerList.Add(Player);
                    }
                    sw.Stop();
                    //Logger.LSDebug.PrintLine(string.Format("Updated Players. ({0} Players in list.) - Elapsed time: {1}ms", PlayerList.Count, sw.ElapsedMilliseconds), LSDebug.TextType.Success);
                    UpdateGrid();
                    for(int i = 0; i < 50; i++)
                        CylMemLite.WriteByte((int)Modules.ClientDLLAdress + Signatures.force_update_spectator_glow, 235);
                    //SDK.Functions.Helpers.Sleep(5000);
                    Application.DoEvents();
                    Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }

        public static void AntiCore()
        {
            while(true)
            {
                try
                {
                    if (Engine.GameState == SDK.Classes.Enums.GameState.FULL) // ON IN GAME
                    {
                        playerLoop:
                        foreach (CSPlayer player in PlayerList)
                        {
                            if (player.BaseAddress == IntPtr.Zero)
                                goto playerLoop;
                            if (player.Team == SDK.Classes.Enums.Team.CounterTerrorist)
                                player.Glow(0.113f, 0.145f, 0.204f, 2);
                            else
                                player.Glow(0.254f, 0.236f, 0.124f, 2);
                        }
                    }
                    Application.DoEvents();
                    Thread.Sleep(5000);
                    Application.DoEvents();
                }
                catch
                {
                    continue;
                }
            }
        }

        public static void UpdateGrid()
        {
            foreach (var Player in PlayerList)
            {
                Logger.LSDebug.SetVariable("Weapon Name", Player.WeaponName, Player.Name);
                Logger.LSDebug.SetVariable("Health", Player.Health, Player.Name);
                Logger.LSDebug.SetVariable("Armor", Player.ArmorValue, Player.Name);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiCoreCheat.Versions.ALPHA
{
    public partial class Main : Form
    {
        static List<SDK.Entities.CSPlayer> PlayerList = new List<SDK.Entities.CSPlayer>();
        public Main()
        {
            InitializeComponent();
        }
        static Thread UpdatePlayersThrd = new Thread(new ThreadStart(UpdatePlayers));
        static Thread UpdateDebuggerGridThrd = new Thread(new ThreadStart(UpdateDebuggerGrid));

        static SDK.Entities.CSLocalPlayer LocalPlayer;

        private void Main_Load(object sender, EventArgs e)
        {
            SDK.SDKManager.Enums.InitalizeResult Result = SDK.SDKManager.Initalize();
            if(Result == SDK.SDKManager.Enums.InitalizeResult.Succes)
            {
                Logger.LSDebug.PrintLine(Logger.GetCurrentMethodName() + " has been invoked!", LSDebug.TextType.Info);
            }
            else
            {
                MessageBox.Show("Error : " + Result.ToString(), "AntiCore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            LocalPlayer = new SDK.Entities.CSLocalPlayer();
            Logger.LSDebug.LSTV.Rows.Clear();
            UpdatePlayersThrd.Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.LSDebug.SaveLog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public static void UpdatePlayers()
        {
            Logger.LSDebug.PrintLine("Started player loop...", LSDebug.TextType.Info);
            for (int i = 0; i <= SDK.Game.Engine.MaxPlayer; i++)
            {
                SDK.Entities.CSPlayer Player = new SDK.Entities.CSPlayer(i);
                if ((Player.Team == SDK.Classes.Enums.Team.CounterTerrorist || Player.Team == SDK.Classes.Enums.Team.Terrorist) && Player.EntityIndex != LocalPlayer.EntityIndex && Player.Name != LocalPlayer.Name && LocalPlayer.BaseAddress != Player.BaseAddress)
                {
                    PlayerList.Add(Player);
                }
            }
            UpdateDebuggerGridThrd.Start();
        }
        public static void UpdateDebuggerGrid()
        {
            Logger.LSDebug.PrintLine("Started datagrid loop...", LSDebug.TextType.Info);
            while (true)
            {
                foreach (var Player in PlayerList)
                {
                    Logger.LSDebug.SetVariable(Player.Name, Player.Health);
                }
                Thread.Sleep(300);
            }
        }
    }
}
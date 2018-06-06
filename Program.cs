#region using
using System;
using System.IO;
using Reborn.Database;
using Reborn.Dofus.D20;
using Reborn.Dofus.D2P;
using Reborn.Managers;
using Reborn.Network;
#endregion

namespace Reborn
{
    class Program
    {
        public static Listener Auth = new Listener();
        public static Listener World = new Listener();

        public static byte[] RawDataMessage = File.ReadAllBytes(Variables.RawDataMessage);

        static void Main(string[] args)
        {
            D2pManager.Setup(Variables.Maps);
            Handle.Setup();

            Auth.Start(Variables.Auth);
            Console.WriteLine("- - Auth Started - -");
            World.Start(Variables.World);
            Console.WriteLine("- - World Started - -");

            Console.WriteLine("= = = LOAD D20 FILES = = =");
            ObjectDataManager.Initialize(Variables.d2opath);

            EffectsManager.Init();
            ItemsManager.Init();

            Console.Read();
        }


        //Add plus tard
        static void Crash(object sender, UnhandledExceptionEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.ResetColor();

            //save en cas de crash
            //Navicat.Save();

            Environment.Exit(1);
        }
    }
}
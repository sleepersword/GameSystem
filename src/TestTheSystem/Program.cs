using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSystem;
using GameSystem.Items;
using System.IO;
using System.Diagnostics;

namespace TestTheSystem
{
    class Program
    {
        static Character ch;
        
        static void Main(string[] args)
        {
            int id = IdentityManager.CreateFullID(IdentityType.Character, 77, 123456);
            ch = new Character(id, "Heino");
            ch.Skills.OnLeveledUp += Lib_OnLeveledUp;

            while (ch.Skills["lvl"] != 100)
            {
                ch.Skills["str"] += CentralUtilities.RandomInteger(0, 2);
                ch.Skills["dex"] += CentralUtilities.RandomInteger(0, 2);
                ch.Skills["int"] += CentralUtilities.RandomInteger(0, 2);
                ch.LevelUpManually();
            }
            
            //Console.Write("Enter savename: ");
            //string path = Console.ReadLine();
            //using (FileStream fs = File.Open(path, FileMode.Create))
            //{
            //    Character.Serialize(ch, fs);
            //}

            //Console.Write("Enter savename: ");
            //string path = Console.ReadLine();
            //using (FileStream fs = File.Open(path, FileMode.Open))
            //{
            //    ch = Character.Deserialize(fs);
            //}

            //Console.WriteLine(ch.ID);
            //Console.WriteLine(ch.Name);
            //Console.WriteLine(ch.Skills);

            Console.Read();
        }

        private static void Lib_OnLeveledUp(object sender, SkillEventArgs e)
        {
            Console.WriteLine(ch.Skills);
        }

        static void HandleInput()
        {
            
        }
    }
}

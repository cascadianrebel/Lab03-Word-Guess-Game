using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateWordBank();
        }

        static void CreateWordBank()
        {
            string path = "../../../WordBank.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("This is my Word Bank");
            }
        }
      
    }
}

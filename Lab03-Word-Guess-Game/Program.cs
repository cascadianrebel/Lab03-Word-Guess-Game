using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    class Program
    {
        static string path = "../../../WordBank.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //File created
            CreateWordBank();
            //read the word bank
            ReadWordBank();
            //update the word bank
            UpdateWordBank();
            //reads word bank after update
            Console.WriteLine("testing update");
            ReadWordBank();
        }
        /// <summary>
        /// creates the file called WordBank.txt
        /// </summary>
        static void CreateWordBank()
        {
            // checks if the file already exists
            if (!File.Exists((path)))
            {
                //creates the file if it doesn't already exist
                using (StreamWriter sw = new StreamWriter(path))
                    {
                        //puts intial text in file
                        sw.Write("This is my Word Bank");
                    }
            }
        }
        
        /// <summary>
        /// accesses the content of the WordBank file
        /// </summary>
        static void ReadWordBank()
        {
            //creates an array from the WordBank
            try
                {
                string[] WordBank = File.ReadAllLines(path);
                //iterates through array of words created from each line of the Word Bank
                    foreach (string value in WordBank)
                    {
                        Console.WriteLine(value);
                    }
                }
            catch (Exception)
                {
                    Console.WriteLine("Something went wrong");
                }
        }
        
        /// <summary>
        /// allows user to update Word bank
        /// </summary>
        static void UpdateWordBank()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                //proof of life in "NewWord"
                sw.WriteLine("NewWord");
            }
        }


      
    }
}

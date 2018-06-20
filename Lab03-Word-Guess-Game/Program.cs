using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Lab03_Word_Guess_Game
{
    class Program
    {
        public static string path = "../../../WordBank.txt";

        public static string[] initialBank = new string[] { "apple", "banana", "orange", "lemon", "cucumber", "blueberry", "grapes", "plum" };


        static void Main(string[] args)
        {

            //File created
            CreateWordBank(initialBank);

            // Display the home screen
            DisplayHome();

        }

        public static void DisplayHome()
        {
            Console.WriteLine("_________________________");
            Console.WriteLine("*************************");
            Console.WriteLine("`````Word Guess Game`````");
            Console.WriteLine("*************************");
            Console.WriteLine("Select an option number then press enter");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Game Settings");
            Console.WriteLine("3. Quit Game");
            Console.WriteLine("------------------------");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        Console.Clear();
                        OptionsMenu();
                        break;
                    case 3:
                        Console.WriteLine("So long friend :( ");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please make valid selection");
                        DisplayHome();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("**Please only enter numbers 1-3**");
                DisplayHome();
                throw;
            }

        }


        public static void StartGame()
        {
            SelectWord();
        }

        static string SelectWord()
        {
            //create the wordBank by reading each line in the wordBank text file
            string[] wordBank = File.ReadAllLines(path);

            //select a random index position from the wordBank array
            Random rand = new Random();
            int randomWordIndex = rand.Next(wordBank.Length);

            //get the word using the random index 
            string randomWord = wordBank[randomWordIndex];

            GamePlay(randomWord);

            return randomWord;
        }

        static string GamePlay(string Word)
        {
            //create the blank array using the length of the random word
            string[] letterTiles = new string[Word.Length];

            string[] guessedLetters = new string[26];

            int counter = 0;

            string blank = "_";

            Console.WriteLine("To Guess the word below, type the letter you've chosen, then press enter");


            //loop through the word and replace each letter with an underscore
            foreach (var i in letterTiles)
            {
                Console.Write(blank);
                Console.Write(" ");
            }

            string userGuess = Console.ReadLine();
            string letterGuessed = userGuess.ToString();
            guessedLetters[counter] = letterGuessed;

            if (Word.Contains(letterGuessed))
            {
                for (var i = 0; i < Word.Length; i++)
                {   
                    if (Word[i] == Convert.ToChar(letterGuessed))
                    {
                        letterTiles[i] = letterGuessed;
                    }
                    else             
                    {
                        letterTiles[i] = blank;
                    }
                Console.Write($"{letterTiles[i]} ");
                }
            
            }
            
            return GamePlay(Word);
        }

        /// <summary>
        /// shows user View, Add, and Delete display screen
        /// </summary>
        static void OptionsMenu()
        {
            Console.WriteLine("________________________");
            Console.WriteLine("~~~~~~GAME Options~~~~~~");
            Console.WriteLine("Select an option number then press enter");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. View Word Bank");
            Console.WriteLine("2. Add New Word To Bank");
            Console.WriteLine("3. Remove Word from Bank");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("------------------------");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        DisplayWordBank();
                        OptionsMenu();
                        break;
                    case 2:
                        DisplayWordBank();
                        AddToWordBank();
                        break;
                    case 3:
                        DisplayWordBank();
                        RemoveFromWordBank();
                        break;
                    case 4:
                        Console.Clear();
                        DisplayHome();
                        break;
                    default:
                        Console.WriteLine("Please make valid selection");
                        OptionsMenu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("**Please only enter numbers 1-4**");
                OptionsMenu();
                throw;
            }

        }

        /// <summary>
        /// creates the file called WordBank.txt
        /// </summary>
        static void CreateWordBank(string[] words)
        {
            // checks if the file already exists
            if (!File.Exists(path))
            {
                //creates the file if it doesn't already exist
                using (StreamWriter sw = new StreamWriter(path))
                    try
                    {
                        //iterates through array of words and puts intial words in file, each on its own line
                        foreach (string s in words)
                        {
                            sw.WriteLine(s);
                        }
                    }
                    finally
                    {
                        sw.Close();
                    }
            }
            else
            {
                DeleteFile(path);
                CreateWordBank(words);
            }

        }

        /// <summary>
        /// accesses the content of the WordBank file
        /// </summary>
        static void DisplayWordBank()
        {
            Console.Clear();
            //displays each element in the word bank
            try
            {
                string[] wordBank = File.ReadAllLines(path);

                //iterates through array of words created from each line of the Word Bank
                foreach (string value in wordBank)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// allows user to update Word bank
        /// </summary>
        static void AddToWordBank()
        {
            Console.Clear();
            DisplayWordBank();

            using (StreamWriter sw = File.AppendText(path))
            {
                //adds word to text file
                Console.WriteLine("Please type the word you'd like to add to the Word Bank then press enter ");
                string Word2Add = Console.ReadLine();
                sw.WriteLine(Word2Add);;
            }
            Console.Clear();
            DisplayWordBank();
            OptionsMenu();
        }

        /// <summary>
        /// INCOMPLETE: removing word from word bank
        /// </summary>
        static void RemoveFromWordBank()
        {
            string[] wordBank = File.ReadAllLines(path);

            string[] updateWordBank = new string[wordBank.Length-1];

            int counter = 0;

            Console.WriteLine("Please enter the word you'd like removed from the wordBank");
            string Word2Remove = Console.ReadLine();

            for (int k = 0; k < wordBank.Length; k++)
            {
                if (wordBank[k] != Word2Remove)
                {
                    updateWordBank[counter] = wordBank[k];
                Console.WriteLine($"Counter is {counter}. K is {k}. Updated Bank is '{updateWordBank[counter]}' with a length of {updateWordBank.Length}. Word bank is {wordBank[k]}");
                    counter++;
                }
                else
                {
                    Console.WriteLine("else hit");
                }

            }

            CreateWordBank(updateWordBank);
            DisplayWordBank();
            OptionsMenu();
        }

        /// <summary>
        /// deletes the file
        /// </summary>
        static void DeleteFile(string FilePath)
        {
            File.Delete(FilePath);
        }
    }
}

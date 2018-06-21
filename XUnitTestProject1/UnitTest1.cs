using System;
using System.IO;
using Xunit;
using Lab03_Word_Guess_Game;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateFile()
        {
            string[] testArray = new string[2];
            Program.CreateWordBank(testArray);
            Assert.True(File.Exists(Program.path));
        }

        [Fact]
        public void CanReadFile()
        {
            string[] testArray = new string[2] { "fizz", "buzz" };
            Program.CreateWordBank(testArray);
            Program.DisplayWordBank();
            string[] testBank = File.ReadAllLines(Program.path);
            Assert.Equal(testArray, testBank);
        }

        [Fact]
        public void CanDeleteFile()
        {
            string[] testArray = new string[2];
            Program.CreateWordBank(testArray);
            Program.DeleteFile(Program.path);
            Assert.False(File.Exists(Program.path));
        }

        //[Theory]
        //[InlineData ("fizz")]
        //public void CanChooseLetters(Program.word)
        //{
        //    string[] testArray = new string[2] { "fizz", "buzz" };
        //    Program.CreateWordBank(testArray);
        //    GamePlay(word)
        //    Assert.False(File.Exists(Program.path));
        //}



      
    }
}

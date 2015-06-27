using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 105;
            ConsoleUtilities.SetWindowPos(ConsoleUtilities.MyConsole, 0, 500, 300, 0, 0, ConsoleUtilities.SWP_NOSIZE);

            WriteHeaderInfo();

            ConsoleKeyInfo startKey;
            Console.WriteLine("Press Enter to start...");
            startKey = Console.ReadKey(true);

            while (startKey.Key != ConsoleKey.Enter)
            {
                startKey = Console.ReadKey(true);
            }

            bool isFileCountValid = false;
            int fileCount = 0;
            ConsoleKeyInfo fileCountKey;
            while (!isFileCountValid)
            {
                Console.WriteLine("How many files to generate? (5000 max)");
                var fileCountEntered = Console.ReadLine();
                isFileCountValid = int.TryParse(fileCountEntered, out fileCount);

                if (!isFileCountValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"'{fileCountEntered}' is not a valid number. Press Enter to try again...");
                    Console.ResetColor();
                    fileCountKey = Console.ReadKey(true);
                    while (fileCountKey.Key != ConsoleKey.Enter)
                    {
                        fileCountKey = Console.ReadKey(true);
                    }

                    continue;
                }

                isFileCountValid = fileCount < 5000;
                if (!isFileCountValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"'{fileCountEntered}' is greater than 5000 max. Press Enter to try again...");
                    Console.ResetColor();
                    fileCountKey = Console.ReadKey(true);
                    while (fileCountKey.Key != ConsoleKey.Enter)
                    {
                        fileCountKey = Console.ReadKey(true);
                    }

                    continue;
                }
            }

            bool isExtentionValid = false;
            while (!isExtentionValid)
            {
                ConsoleKeyInfo extentionKey;
                Console.WriteLine("What file extention to use? ('.txt','.pdf', '.csv' or other)");
                var extentionEntered = Console.ReadLine();
                isExtentionValid = extentionEntered.StartsWith(".");

                //dot validation
                if (!isExtentionValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Anwser must start with a dot '.'. Example '.txt'. Press Enter to try again...");
                    Console.ResetColor();
                    extentionKey = Console.ReadKey(true);
                    while (extentionKey.Key != ConsoleKey.Enter)
                    {
                        extentionKey = Console.ReadKey(true);
                    }

                    continue;
                }

                //length validation
                isExtentionValid = extentionEntered.Length == 4;
                if (!isExtentionValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Anwser must contain 4 characters including the dot '.'. Example '.txt' is 4 characters in length. Press Enter to try again...");
                    Console.ResetColor();
                    extentionKey = Console.ReadKey(true);
                    while (extentionKey.Key != ConsoleKey.Enter)
                    {
                        extentionKey = Console.ReadKey(true);
                    }

                    continue;
                }
            }

                Console.WriteLine("Custom naming convention (2015_Ford_F150_x) where 'x' is the incrementer? y/n");
                ConsoleKeyInfo namingAnswerEntered = Console.ReadKey(true);

                while (true)
                {
                    if (namingAnswerEntered.Key == ConsoleKey.Y
                        || namingAnswerEntered.Key == ConsoleKey.N)
                    {
                        Console.WriteLine(namingAnswerEntered.KeyChar);
                        break;
                    }
                    else
                        namingAnswerEntered = Console.ReadKey(true);
                }

            bool hasCustomNameConvention = namingAnswerEntered.Key == ConsoleKey.Y ? true : false;

            if (hasCustomNameConvention)
            {
                Console.WriteLine("Choose a delimiter for the sequence ('_', '-', '!', ',')");
                ConsoleKeyInfo delimiterEntered = Console.ReadKey(true);

                while (true)
                {
                    if (delimiterEntered.KeyChar == Char.Parse("_")
                        || delimiterEntered.KeyChar == Char.Parse("-")
                        || delimiterEntered.KeyChar == Char.Parse("!")
                        || delimiterEntered.KeyChar == Char.Parse(","))
                    {
                        Console.WriteLine(delimiterEntered.KeyChar);
                        break;
                    }
                    else
                        delimiterEntered = Console.ReadKey(true);
                }

                Console.WriteLine("How many delimiters in file name? (8 max)");
                ConsoleKeyInfo delimiterCountEntered = Console.ReadKey(true);

                int delimiterCount = 0;
                while (true)
                {
                    if (char.IsNumber(delimiterCountEntered.KeyChar)
                        && int.Parse(delimiterCountEntered.KeyChar.ToString()) <= 8)
                    {
                        Console.WriteLine(delimiterCountEntered.KeyChar);
                        delimiterCount = int.Parse(delimiterCountEntered.KeyChar.ToString());
                        break;

                    }
                    else
                        delimiterCountEntered = Console.ReadKey(true);
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("NOTE: You can have multiple sequences.");
                Console.WriteLine("Example: set 1, 10 files with a sequence of 2003_Ford_F150_x");
                Console.WriteLine("Example: set 2, 20 files with a sequence of 2015_Honda_Civic_x");
                Console.WriteLine("Example: set 3, 70 files with a sequence of 1969_Chevy_Camero_x");
                Console.ResetColor();

                var exampleSequenceFileName = new StringBuilder();
                for (int i = 0; i < delimiterCount; i++)
                {
                    exampleSequenceFileName.Append("XXXX");
                    exampleSequenceFileName.Append($"{delimiterEntered.KeyChar}");
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Example based on {delimiterCountEntered.KeyChar} delimiters: {exampleSequenceFileName.ToString()}");
                Console.ResetColor();
                Console.WriteLine($"Enter sequence file name with {delimiterCountEntered.KeyChar} delimiters and press Enter.");

                var sequence1 = Console.ReadLine();
                Console.WriteLine($"You entered {sequence1}");
                //Console.WriteLine($"You requested {fileCount} files.  How many different sets or sequences do you want to split the count by? (your can enter 1 to have all files the same sequence)");
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine($"Example: 2012_Ford_F150_x, 2013_Toyota_4Runner_x, and 2016_Honda_Civic_x is 3 sequences...");
                //Console.ResetColor();

                //ConsoleKeyInfo sequencesCountEntered = Console.ReadKey(true);

                //while (true)
                //{
                //    if (char.IsNumber(sequencesCountEntered.KeyChar)
                //        && int.Parse(sequencesCountEntered.KeyChar.ToString()) <= 8)
                //    {
                //        Console.WriteLine(sequencesCountEntered.KeyChar);
                //        break;

                //    }
                //    else
                //        sequencesCountEntered = Console.ReadKey(true);
                //}

            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("ok");
            Console.ReadKey();
        }

        private static void WriteHeaderInfo() {
            var tablewidth = 77;
            var vertline = new string('-', tablewidth);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + vertline.Length / 2) + "}", vertline);

            Console.ForegroundColor = ConsoleColor.Cyan;
            var title = $"FileGenerator version {typeof(Program).Assembly.GetName().Version}";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + title.Length / 2) + "}", title);
            Console.ResetColor();
            var author = "author: Corey Harbaugh";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + author.Length / 2) + "}", author);
            var email = "email: corey.harbaugh@gmail.com";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + email.Length / 2) + "}", email);
            var date = "date: June 25th, 2015";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + date.Length / 2) + "}", date);
            var github = "github: https://github.com/chdev77/FileGenerator";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + github.Length / 2) + "}", github);

            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + vertline.Length / 2) + "}", vertline);

        }
    }



    internal static class ConsoleUtilities {
        public const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        public static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    }
}

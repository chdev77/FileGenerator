using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHeaderInfo();

            ConsoleKeyInfo startKey;
            Console.WriteLine("Press Enter to start...");
            startKey = Console.ReadKey(true);

            while (startKey.Key != ConsoleKey.Enter)
            {
                startKey = Console.ReadKey(true);
            }

            bool isFileCountValid = false;
            int fileCount;
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

            bool hasCustomNameConvention = false;
            Console.WriteLine("Custom naming convention (2015_Ford_F150_x) where 'x' is the incrementer? y/n");

            ConsoleKeyInfo customNameKey = Console.ReadKey(true);
            while (customNameKey.Key != ConsoleKey.Y && customNameKey.Key != ConsoleKey.N)
            {
                customNameKey = Console.ReadKey(true);
            }

            hasCustomNameConvention = customNameKey.Key == ConsoleKey.Y ? true : false;

            if (hasCustomNameConvention) {




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
}

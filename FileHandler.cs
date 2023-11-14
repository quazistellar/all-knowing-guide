using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideMaster
{
    internal static class FileHandler
    {
        public static void AddFile(string p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" >> Введите название файла (без расширения!!!): ");
            Console.ResetColor();
            string fileName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write(" >> Введите расширение файла: ");
            Console.ResetColor();
            string fileExtension = Console.ReadLine();
            string filePath = Path.Combine(p, $"{fileName}.{fileExtension}");
            using (File.Create(filePath)) { }
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Файл '{fileName}.{fileExtension}' создан");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("нажмите что-то чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            Program.Main();
        }

        public static void AddDirectory(string p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" >> Введите имя для новой папки: ");
            Console.ResetColor();

            string foldername = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            string folderPath = Path.Combine(p, foldername);
            Directory.CreateDirectory(folderPath);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Папка '{foldername}' создана!");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("нажмите что-то, чтобы продолжить");
            Console.ResetColor();
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            Program.Main();
        }

        public static void DeleteItem(string p)
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.Write(">> Введите название файла (с расширением)/директории для удаления: ");
            Console.ResetColor();

            string itemName = Console.ReadLine();

            string fullPath = Path.Combine(p, itemName);

            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Файл '{itemName}' удален");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------");

                }
                else if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Папка '{itemName}' удалена");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------");
                }
                else
                {
                    Console.WriteLine("такого на компьютере нет!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка при удалении {itemName}: {ex.Message}");
            }
            
            Console.WriteLine("нажмите что-то чтобы продолжить");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            Program.Main();
        }
    }
}
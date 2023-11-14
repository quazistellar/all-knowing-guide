using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GuideMaster
{
    internal static class ExploreGuide
    {
        public static void diski()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.ForegroundColor = ConsoleColor.Yellow;
          
            Console.WriteLine("  Доступные диски:");
            Console.ResetColor();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("  " + drive.Name + "" + drive.AvailableFreeSpace / (1024 * 1024 * 1024) + " ГБ " + "свободно из " + drive.TotalSize / (1024 * 1024 * 1024) + " ГБ");
            }

            int selectedPos = ArrowsMenu.Show(4, 4, 5);

            switch (selectedPos)
            {
                case 4:
                    ShowPapka("C:\\");
                    break;
                case 5:
                    try
                    {
                        ShowPapka("D:\\");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("такого нет");

                    }
                    break;
                case 6:
                    try
                    {
                        ShowPapka("E:\\");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("такого нет");

                    }
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("---------------------------------");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы завершили работу с программой!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("---------------------------------");
                    Console.ResetColor();
                    break;
                case -4:
                    Console.Clear();
                    Program.Main();
                    break;
                case -3:
                    Console.Clear();
                    Program.Main();
                    break;
                case -2:
                    Console.Clear();
                    Program.Main();
                    break;
                default:
                    break;
            }
        }
        public static void ShowPapka(string p)
        {
            while (true)
            {

                try
                {
                    Console.Clear();


                    string[] road = Directory.GetFileSystemEntries(p);

                    if (road.Length == 0)
                    {
                        Console.WriteLine("  тут пусто");
                        int pos1 = ArrowsMenu.Show(0, 0, 0);


                    }
                    else
                    {
                        int longn = road.Max(s => Path.GetFileName(s).Length);
                        string word1 = "Название";
                        string word2 = "Тип";
                        string word3 = "Дата создания";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("                                     " + ">>> " + word1 + " | " + word2 + " | " + word3 + " <<<       ");
                        Console.ResetColor();
                        foreach (var item in road)
                        {
                            string itemName = Path.GetFileName(item);
                            string itemInfo = "";
                            string iteminfdate = "";

                            string space = new string(' ', longn - itemName.Length);

                            if (File.Exists(item))
                            {
                                FileInfo fileInfo = new FileInfo(item);
                                itemInfo = $"            ({fileInfo.Extension})";

                                if (fileInfo.Extension.Length < 5)
                                {
                                    iteminfdate = $"               {fileInfo.CreationTime}";
                                    Console.WriteLine($"  {itemName.PadRight(longn)} {itemInfo.PadRight(35)} {iteminfdate.PadRight(10)}");
                                }
                                else
                                {
                                    iteminfdate = $"               {fileInfo.CreationTime}";
                                    Console.WriteLine($"  {itemName.PadRight(longn)} {itemInfo.PadRight(35)} {iteminfdate.PadRight(10)}");
                                }


                            }
                            else if (Directory.Exists(item))
                            {

                                DirectoryInfo dirInfo = new DirectoryInfo(item);
                                itemInfo = "            (папка)";
                                iteminfdate = $"               {dirInfo.CreationTime}";
                                Console.WriteLine($"  {itemName.PadRight(longn)} {itemInfo.PadRight(35)} {iteminfdate.PadRight(10)}");
                            }
                        }


                    }

                    int pos = ArrowsMenu.Show(1, 1, road.Length);

                    if (pos == -1)
                    {
                        if (p.Length > 3)
                        {
                            ShowPapka(Path.GetDirectoryName(p));
                            return;
                        }
                        else
                        {
                            Program.Main();
                            break;
                        }
                    }
                    else if (pos == -2)
                    {
                        FileHandler.AddDirectory(p);
                    }
                    else if (pos == -3)
                    {
                        FileHandler.AddFile(p);
                    }
                    else if (pos == -4)
                    {
                        FileHandler.DeleteItem(p);
                    }
                    else
                    {
                        if (Directory.Exists(road[pos - 1]))
                        {
                            p = road[pos - 1];
                            continue;
                        }
                        else
                        {
                            string filePath = road[pos - 1];
                            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("такого нет, тут какая-то ошибка: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("чтобы вернуться в меню выбора дисков, нажмите 'Enter'");
                    ConsoleKeyInfo key;
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Program.Main();
                        return;
                    }
                }
            }
        }
    }
}
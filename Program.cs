using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideMaster
{
    internal class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string s = " >>>>> ПРОВОДНИК <<<<<";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();
            string s1 = "-----------------------------------------------------------------------------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.CursorTop);
            Console.WriteLine(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string s2 = "Этот компьютер | (Z - удалить папку/файл, X - создать файл, C - создать папку) |";
            Console.SetCursorPosition((Console.WindowWidth - s2.Length) / 2, Console.CursorTop);
            Console.WriteLine(s2);
            Console.ResetColor();
            ExploreGuide.diski();
        }
    }
}

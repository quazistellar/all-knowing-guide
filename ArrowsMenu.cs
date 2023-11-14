using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideMaster
{
    internal static class ArrowsMenu
    {
        public static int Show(int pos, int minStrelochka, int maxStrelochka)
        {

            ConsoleKeyInfo key;

            do
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, pos);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("->");
                Console.ResetColor();

             
                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");


                if (key.Key == ConsoleKey.UpArrow && pos != minStrelochka)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != maxStrelochka)
                {
                    pos++;
                }

                else if (key.Key == ConsoleKey.Z) 
                {
                    return -4;
                }

                else if (key.Key == ConsoleKey.X) 
                {

                    return -3;
                }

                else if (key.Key == ConsoleKey.C)
                {
                    return -2;
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return -1;
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.Clear();
            return pos;
            
        }
    }
}

using System;
using ConsoleGame.Windows;
using ConsoleGame.Controls;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleGame
{
    class Program
    {
        //config
        const int MF_BYCOMMAND = 0x00000000;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        
        static void Main()
        {
            bool isActive = true;
            SetupScreen();

            MainMenu mainMenu = new MainMenu(0, 0, 120, 29);
            while (isActive)
            {
                mainMenu.Start();

            }

            Console.ReadKey();
        }

        private static void SetupScreen()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);

            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}

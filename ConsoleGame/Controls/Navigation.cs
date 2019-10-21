using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class Navigation
    {
        public int WaitForMenuInput()
        {
            ConsoleKeyInfo keyDown;

            keyDown = Console.ReadKey(true);
            switch (keyDown.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return 1;
                    }
                case ConsoleKey.DownArrow:
                    {
                        return 1;
                    }
                case ConsoleKey.UpArrow:
                    {
                        return -1;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return -1;
                    }
                case ConsoleKey.Enter:
                    {
                        return 2;
                    }
                case ConsoleKey.Escape:
                    {
                        return -100;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}

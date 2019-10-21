using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Windows;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class Input : GameObject, IREnderable
    {
        private char frameChar = '+';
        private Frame frame;
        private string inputText;
        private TextLine text;
        private int x, y, width, height;

        public Input(int x, int y, int width, int height, string inputText) : base(x, y, width, height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.inputText = inputText;
        }

        private void AssignFrame()
        {
            frame = new Frame(x, y, width, height, frameChar);
        }

        private void AssignText()
        {
            text = new TextLine(x + width / 2 - inputText.Length / 2, y + height / 2 - 1, width, inputText);
        }

        public string GetInput()
        {
            string returnText;
            Console.CursorVisible = true;
            Console.SetCursorPosition(x + width / 2 - inputText.Length / 2, y + height / 2 + 1);
            returnText = Console.ReadLine();
            Console.CursorVisible = false;
            return returnText;
        }

        public override void Render()
        {           
            AssignFrame();
            AssignText();
            frame.Render();
            text.Render();
        }
    }
}

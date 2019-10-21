using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Windows;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class Button : GameObject, IREnderable, IPickable
    {
        private char inactiveButtonChar = '-';
        private char activeButtonChar = '+';
        private bool isActive = false;
        private Frame frame;
        private string buttonText;
        private TextLine text;
        private int x, y, width, height;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                AssignFrame();
                text.X = (x + Width / 2 - buttonText.Length / 2);
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                AssignFrame();
                text.Y = y + (Height / 2);
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Button(int x, int y, int width, int height, string buttonText) : base (x, y, width, height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.buttonText = buttonText;
            AssignFrame();
            AssignText();
        }

        private void AssignFrame()
        {
            if (isActive)
            {
                frame = new Frame(x, y, width, height, activeButtonChar);
            }
            else
            {
                frame = new Frame(x, y, width, height, inactiveButtonChar);
            }            
        }

        private void AssignText()
        {
            text = new TextLine(x + width / 2 - buttonText.Length / 2, y + height / 2, width, buttonText);
        }

        public void SetActive()
        {
            isActive = true;
            Render();
        }

        public void SetInactive()
        {
            isActive = false;
            Render();
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

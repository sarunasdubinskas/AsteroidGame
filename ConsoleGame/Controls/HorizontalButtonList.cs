using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Controls;
using ConsoleGame.Windows;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class HorizontalButtonList : GameObject, IREnderable
    {
        private int x, y, width, height;
        private List<Button> buttons;
        private int menuButtonsXPadding;
        private int defaultMenuButtonsYPaddingFromBottom = 2;

        public HorizontalButtonList(int x, int y, int width, int height, List<Button> buttons) : base(x, y, width, height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.buttons = buttons;
        }

        public void OrganizeButtons()
        {
            if (buttons.Count == 0)
            {
                return;
            }
            else
            {
                menuButtonsXPadding = (width - buttons[0].Width * buttons.Count) / (buttons.Count + 1);

                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].X = x + i * menuButtonsXPadding + menuButtonsXPadding + buttons[0].Width * i;
                    buttons[i].Y = y + height - defaultMenuButtonsYPaddingFromBottom - buttons[0].Height;
                }
            }
        }

        public override void Render()
        {
            foreach (Button button in buttons)
            {
                button.Render();
            }
        }
    }
}

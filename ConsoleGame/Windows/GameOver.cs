using ConsoleGame.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class GameOver : Window, IREnderable
    {
        private int x, y, width, height;
        private Button backButton;
        private Navigation navigation;
        private List<Button> buttons = new List<Button>();
        private HorizontalButtonList horizontalButtonList;
        private Frame windowFrame;
        private TextBlock gameOverTextBlock;
        private readonly List<string> gameOverText = new List<string>();
        private int defaultButtonWidth = 20;
        private int defaultButtonHeight = 5;
        private char borderChar;
        private bool isPicking = true;
        private int activeButton;

        public GameOver(int x, int y, int width, int height, char borderChar) : base(x, y, width, height, borderChar)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.borderChar = borderChar;
            windowFrame = new Frame(x, y, width, height, borderChar);
            gameOverText.Add("Game Over....");
            gameOverTextBlock = new TextBlock(x, y, width, gameOverText.Count, gameOverText);
            CreateButtonArray();
            PlaceButtons();
        }

        public void Start()
        {
            {
                int key;
                Render();
                navigation = new Navigation();
                buttons[0].SetActive();
                PlaceButtons();
                while (isPicking)
                {
                    key = navigation.WaitForMenuInput();
                    switch (key)
                    {
                        case 1:
                            {
                                if (activeButton + key >= 0 && activeButton + key < buttons.Count)
                                {
                                    buttons[activeButton].SetInactive();
                                    activeButton += key;
                                    buttons[activeButton].SetActive();
                                    horizontalButtonList.Render();
                                }
                                break;
                            }
                        case -1:
                            {
                                if (activeButton + key >= 0 && activeButton + key < buttons.Count)
                                {
                                    buttons[activeButton].SetInactive();
                                    activeButton += key;
                                    buttons[activeButton].SetActive();
                                    horizontalButtonList.Render();
                                }
                                break;
                            }
                        case 2:
                            {
                                Pick(activeButton);
                                break;
                            }
                        case -100:
                            {
                                Pick(activeButton);
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                    }
                }
            }
        }

        private void Pick(int activeButton)
        {
            switch (activeButton)
            {
                case 0:
                    {
                        isPicking = false;
                        break;
                    }
            }
        }

        private void CreateButtonArray()
        {
            backButton = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Main menu");
            buttons.Add(backButton);
        }

        public void PlaceButtons()
        {
            horizontalButtonList = new HorizontalButtonList(x, y, width, height, buttons);
            horizontalButtonList.OrganizeButtons();
        }

        public override void Render()
        {
            windowFrame.Render();
            gameOverTextBlock.Render();
            horizontalButtonList.Render();
        }
    }
}

using ConsoleGame.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class DifficultyPicker : Window, IREnderable
    {
        int x, y, width, height;
        char frameChar;
        private Button easyButton;
        private Button mediumButton;
        private Button hardButton;
        private Navigation navigation;
        private List<Button> buttons = new List<Button>();
        private HorizontalButtonList horizontalButtonList;
        private Frame windowFrame;
        private TextBlock difficultyTextBlock;
        private readonly List<string> difficultyText = new List<string>();
        private int defaultButtonWidth = 20;
        private int defaultButtonHeight = 5;
        private bool isPicking = true;
        private int activeButton;
        private int difficulty;
        public int Difficulty
        {
            get
            {
                return difficulty;
            }
        }


        public DifficultyPicker(int x, int y, int width, int height, char frameChar) : base(x, y, width, height, frameChar)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.frameChar = frameChar;
            windowFrame = new Frame(x, y, width, height, frameChar);
            difficultyText.Add("Select difficulty");
            difficultyTextBlock = new TextBlock(x, y, width, difficultyText.Count, difficultyText);
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
                case 1:
                    {
                        isPicking = false;
                        break;
                    }
                case 2:
                    {
                        isPicking = false;
                        break;
                    }
            }
        }

        private void CreateButtonArray()
        {
            easyButton = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Todler");
            buttons.Add(easyButton);
            mediumButton = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Sweating");
            buttons.Add(mediumButton);
            hardButton = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "God like");
            buttons.Add(hardButton);
        }

        public void PlaceButtons()
        {
            horizontalButtonList = new HorizontalButtonList(x, y, width, height, buttons);
            horizontalButtonList.OrganizeButtons();
        }

        public override void Render()
        {
            windowFrame.Render();
            difficultyTextBlock.Render();
            horizontalButtonList.Render();
        }
    }
}
        
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Controls;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class MainMenu : Window, IREnderable
    {
        private int x, y, width, height;
        private List<Button> buttons = new List<Button>();
        private Navigation navigation;
        HorizontalButtonList horizontalButtonList;
        GameStatus gameStatus;
        TextBlock title;
        List<string> titleText = new List<string>();
        private int defaultButtonWidth = 20;
        private int defaultButtonHeight = 5;
        private int activeButton;
        private bool isPicking = true;
        private char defaultFrameChar = '#';

        public MainMenu(int x, int y, int width, int height) : base(x, y, width, height, '#')
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            CreateButtonArray();
            gameStatus = new GameStatus();
            titleText.Add("Asteroid field");
            title = new TextBlock(x, y, width, height, titleText);
        }

        private void CreateButtonArray()
        {
            Button startGame = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Start Game");
            Button credits = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Credits");
            Button quit = new Button(x, y, defaultButtonWidth, defaultButtonHeight, "Quit");
            buttons.Add(startGame);
            buttons.Add(credits);
            buttons.Add(quit);
            PlaceButtons();
            buttons[0].SetActive();
        }

        public void Start()
        {
            Render();
            int key;
            navigation = new Navigation();
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
                            }
                            break;
                    }
                    case 2:
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

        private void Pick(int activeButton)
        {
            switch (activeButton)
            {
                case 0:
                    {
                        NamePicker name = new NamePicker(x + 30, y + 5, width - 60, height - 10, '#');
                        name.Render();
                        gameStatus.Name = name.Name;
                        DifficultyPicker difficulty = new DifficultyPicker(x + 20, y + 5, width - 40, height - 10, '#');
                        difficulty.Start();
                        gameStatus.Difficulty = difficulty.Difficulty;
                        GamePlay game = new GamePlay(width, height, gameStatus.Difficulty);
                        game.StartGame();
                        GameOver gameOver = new GameOver(x + 20, y + 5, width - 40, height - 10, '#');
                        gameOver.Start();
                        Start();
                        break;
                    }
                case 1:
                    {
                        Credits credits = new Credits(x+20, y+5, width-40, height-10, '#');
                        credits.Start();
                        Start();
                        break;
                    }
                case 2:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        public void PlaceButtons()
        {
            horizontalButtonList = new HorizontalButtonList(x, y, width, height, buttons);
            horizontalButtonList.OrganizeButtons();
        }

        public override void Render()
        {
            base.Render();
            title.Render();
            horizontalButtonList.Render();
        }
    }
}

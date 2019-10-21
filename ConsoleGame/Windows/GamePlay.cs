using ConsoleGame.Unit;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Windows
{
    class GamePlay: IREnderable
    {
        //vars
        private int width;
        private int height;
        private int enemyCounter;
        private Hero hero;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Enemy> enemiesLastPos = new List<Enemy>();
        private GameStatus gameStatus = new GameStatus();
        private Frame playAreaBorder;
        private int timerForNewEnemy;
        bool isGameActive = true;

        //params
        private int spawnFrequency;
        private int initEnemySpawnCount = 10;
        private string heroName = "Player";
        private string enemyNamePrefix = "Enemy";
        private char playerSymbol = '^';
        private char enemySymbol = '*';
        private int playAreaYPadding = 1;
        private char playAreaBorderChar = '-';
        private int score;

        public GamePlay(int width, int height, int spawnFrequency)
        {
            this.width = width;
            this.height = height;
            SetEnemies(initEnemySpawnCount);
            SetHero(heroName);
            playAreaBorder = new Frame(0, playAreaYPadding, width, height - playAreaYPadding, playAreaBorderChar);
            this.spawnFrequency = spawnFrequency + 1;
            Console.Clear();
            playAreaBorder.Render();
        }

        public void Render()
        {
            UpdateScore();
            CheckForCollision();
            AssignLastPossitionOfEnemies();
            RemoveEnemiesOutsideScreen();
            PlaceObjectsInPlayArea();
            System.Threading.Thread.Sleep(350);
            MoveEnemiesDown();
        }

        private void AssignLastPossitionOfEnemies()
        {
            enemiesLastPos.Clear();
            foreach (Enemy enemy in enemies)
            {
                enemiesLastPos.Add(enemy);
            }
        }

        private void CheckForCollision()
        {
            int counter = 0;
            foreach (Enemy enemy in enemies)
            {
                if(enemy.YPos>hero.YPos && enemy.XPos==hero.XPos)
                {
                    isGameActive = false;
                }
            }
        }

        private void UpdateScore()
        {
            Console.SetCursorPosition(width - 20, 0);
            Console.Write("Score" + score);
        }

        private void PlaceObjectsInPlayArea()
        {
            foreach (Enemy enemy in enemies)
            {
                Console.SetCursorPosition(enemy.XPos, enemy.YPos);
                Console.Write(enemySymbol);
            }
            if (timerForNewEnemy / spawnFrequency > 1)
            {
                SetEnemies(1);
                timerForNewEnemy = 0;
            }
            Console.SetCursorPosition(hero.XPos, hero.YPos);
            Console.Write(playerSymbol);
        }

        private void RemoveEnemiesOutsideScreen()
        {
            int counter = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].YPos > height - 2)
                {
                    enemies.RemoveAt(i);
                    i--;
                    counter++;
                    timerForNewEnemy++;
                    score++;
                }
            }
            SetEnemies(counter);
        }

        private void SetHero(string name)
        {
            hero = new Hero(name, width, height);
        }

        private void SetEnemies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Enemy enemy = new Enemy(name: enemyNamePrefix + enemyCounter, enemyCounter, width, height, playAreaYPadding);
                enemyCounter++;
                enemies.Add(enemy);
            }
        }

        public void MoveHeroRight()
        {
            hero.MoveRight();
        }

        public void MoveHeroLeft()
        {
            hero.MoveLeft();
        }

        public void MoveEnemiesDown()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveDown();
            }
        }

        private Enemy GetEnemyByID(int id)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetID() == id)
                {
                    return enemy;
                }
            }
            return null;
        }

        public void StartGame()
        {
            ConsoleKeyInfo keyDown;

            while (isGameActive)
            {
                Render();
                if (Console.KeyAvailable)
                {
                    keyDown = Console.ReadKey(true);
                    switch (keyDown.Key)
                    {
                        case ConsoleKey.RightArrow:
                            {
                                MoveHeroRight();
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                MoveHeroLeft();
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                isGameActive = false;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }

        }
    }
}

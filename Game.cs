using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                AskForMovement();
            } while (player.Health > 0);

            GameOver();
        }

        void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                player.Health--;
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write("P");
                    else if (room.Monster != null)
                        Console.Write("M");
                    else if (room.Item != null)
                        switch (room.Item.GetType().Name)
                        {
                            case "Weapon":
                                Console.Write("W");
                                break;
                            case "Armor":
                                Console.Write("A");
                                break;
                            case "Consumable":
                                Console.Write("C");
                                break;
                            default:
                                break;
                        }
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        if (random.Next(0, 100) < 10)
                            world[x, y].Monster = GenerateMonster();

                        if (random.Next(0, 100) < 10)
                            world[x, y].Item = GenerateItem();
                    }
                }
            }
        }

        private Item GenerateItem()
        {
            Item item = null;
            int itemSelect = random.Next(0, 3);
            switch (itemSelect)
            {
                case 0:
                    item = new Weapon("Sword", 12, 12, 12);
                    break;

                case 1:
                    item = new Consumable("HealthPotion", 12, 12, 12);
                    break;

                case 2:
                    item = new Armor("Shield", 12, 12, 12);
                    break;
                default:
                    break;
            }
            return item;
        }

        private Monster GenerateMonster()
        {
            Monster monster;
            if (random.Next(0, 100) < 20)
            {
                monster = new Monster(40, "Chimera", 4, 2);
            }
            else
            {
                monster = new Monster(20, "Rat", 2, 0);
            }
            return monster;
        }

        private void CreatePlayer()
        {
            player = new Player(30, 0, 0, 5, 0);
        }
    }
}

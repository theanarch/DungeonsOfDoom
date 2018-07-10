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
            Console.WriteLine($"Health: {player.Health} | Damage: {player.Damage} | Armor: {player.Armor}");
            string backpack = "";
            foreach (var item in player.backpack)
            {
                backpack += item.Name + " ";
            }
            Console.WriteLine($"Backpack: {backpack}");
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
                case ConsoleKey.I: Inventory(); break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                SearchRoom();
            }
        }

        private void Inventory()
        {
            Console.Clear();
            Console.WriteLine($"You have encountered the mighty");
            Console.WriteLine($"Rat says: you wanna die!??");
            Console.WriteLine($"");
            Console.ReadKey();
        }

        private void SearchRoom()
        {
            Room currentRoom = world[player.X, player.Y];
            Monster monster = currentRoom.Monster;
            if (currentRoom.Monster != null)
            {
                player.Fight(monster);
                monster.Fight(player);
                if (monster.Health <= 0)
                {
                    Console.WriteLine($"You have slain a {monster.Name.ToString().ToLower()}");
                    currentRoom.Monster = null;
                    Console.ReadKey();
                }
            }
            else if (currentRoom.Item != null)
            {
                player.AddToBackpack(currentRoom.Item);
                currentRoom.Item = null;
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
                        else if (random.Next(0, 100) < 10)
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
                monster = new Ogre(40, "Ogre", 4, 2);
            }
            else
            {
                monster = new Skeleton(200, "Skeleton", 2, 0);
            }
            return monster;
        }

        private void CreatePlayer()
        {
            player = new Player(30, 0, 0, 5, 0);
        }
    }
}

using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        private const int MAP_WIDTH = 120;
        private const int MAP_HEIGHT = 30;

        static void Main(string[] args)
        {
            Console.SetBufferSize(MAP_WIDTH, MAP_HEIGHT);
            Console.CursorVisible = false;

            Walls walls = new Walls(MAP_WIDTH, MAP_HEIGHT);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(MAP_WIDTH, MAP_HEIGHT, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    GameOver();
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            Console.ReadLine();
        }

        private static void GameOver()
        {
            int left = MAP_WIDTH / 2 - 13;
            int top = MAP_HEIGHT / 2 - 2;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(left, top);
            Console.Write("==========================");

            Console.SetCursorPosition(left, top + 1);
            Console.Write(" И Г Р А  О К О Н Ч Е Н А ");

            Console.SetCursorPosition(left, top + 2);
            Console.Write("                          ");

            Console.SetCursorPosition(left, top + 3);
            Console.Write(" Автор: Александр Тельнов ");

            Console.SetCursorPosition(left, top + 4);
            Console.Write("==========================");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Point
            Point p = new Point(4, 5, '*');
            Figure fsnake = new Snake(p, 4, Direction.RIGHT);
            Draw(fsnake);
            Snake snake = (Snake)fsnake;

            VerticalLine v1 = new VerticalLine(0, 10, 5, '%');
            HorizontalLine h1 = new HorizontalLine(0, 5, 6, '%');

            List<Figure> figures = new List<Figure>();
            figures.Add(fsnake);
            figures.Add(v1);
            figures.Add(h1);

            foreach(var f in figures)
            {
                f.Draw();
            }

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
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

                Thread.Sleep(450);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Handlekey(key.Key);
                }
            }
        }
        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}

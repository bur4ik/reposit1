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

            // Field

            HorizontalLine upline = new HorizontalLine(0,78,0,'+');
            upline.Draw();
            HorizontalLine downline = new HorizontalLine(0, 78, 24, '+');
            downline.Draw();
            VerticalLine leftline = new VerticalLine(0, 24, 0, '+');
            leftline.Draw();
            VerticalLine rightline = new VerticalLine(0, 24, 78, '+');
            rightline.Draw();

            // Point
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while(true)
            {
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
    }
}

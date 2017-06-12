﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 40);
            Console.CursorVisible = false;

            HorizontalLine topLine = new HorizontalLine(0, 78, 0, '—');
            HorizontalLine bottomLine = new HorizontalLine(0, 78, 24, '—');
            VerticalLine leftLine = new VerticalLine(0, 0, 24, '|');
            VerticalLine rightLine = new VerticalLine(78, 0, 24, '|');

            topLine.Draw();
            bottomLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(7, 3, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            
            while(true)
            {
                if(snake.Eat(food))
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowHeight = 4;
            Console.WindowWidth = 4;
        }

        // int screenWidth = Console.WindowWidth;
        // int screenHeight = Console.WindowHeight;
        int screenWidth = 16;
        int screenHeight = 16;

        Random randomNumber = new Random();
        Pixel head = new Pixel();

        head.xPos = screenWidth / 2;
        head.yPos = screenHeight / 2;
        head.color = ConsoleColor.Red;

        string movement = "";
        int score = 0;

        List<int> positions = new List<int>();

        positions.Add(head.xPos);
        positions.Add(head.yPos);

        DateTime time = DateTime.Now;

        string obstacle = "*";
        int obstacleXpos = randomNumber.Next(1, screenWidth - 1);
        int obstacleYpos = randomNumber.Next(1, screenHeight - 1);

        Console.CursorVisible = false;

        while (true)
        {
            ConsoleKeyInfo info = default;
            if (Console.KeyAvailable)
            {
                info = Console.ReadKey(intercept: true);
            }

            //Game Logic
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    movement = movement != "DOWN" ? "UP" : "DOWN";
                    break;

                case ConsoleKey.DownArrow:
                    movement = movement != "UP" ? "DOWN" : "UP";
                    break;

                case ConsoleKey.LeftArrow:
                    movement = movement != "RIGHT" ? "LEFT" : "RIGHT";
                    break;

                case ConsoleKey.RightArrow:
                    movement = movement != "LEFT" ? "RIGHT" : "LEFT";
                    break;
            }

            if (movement == "UP")
                head.yPos--;

            if (movement == "DOWN")
                head.yPos++;

            if (movement == "LEFT")
                head.xPos--;

            if (movement == "RIGHT")
                head.xPos++;

            // Hitting the obstacle
            if (head.xPos == obstacleXpos && head.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = randomNumber.Next(1, screenWidth - 1);
                obstacleYpos = randomNumber.Next(1, screenHeight - 1);
            }
            else
            {
                positions.RemoveAt(positions.Count - 1);
                positions.RemoveAt(positions.Count - 1);
            }

            positions.Insert(0, head.xPos);
            positions.Insert(1, head.yPos);

            Console.Clear();

            // Draw Obstacle
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(head.xPos, head.yPos);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }

            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }

            Console.ForegroundColor =  ConsoleColor.Black;
            Console.WriteLine("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < positions.Count(); i+=2)
            {
                Console.SetCursorPosition(positions[i], positions[i + 1]);
                Console.Write("■");
            }

            //Draw Snake
            Console.SetCursorPosition(head.xPos, head.yPos);
            Console.Write("■");



            // Collision with self or wall
            if (head.xPos == 0 || head.xPos == screenWidth - 1 || head.yPos == 0 || head.yPos == screenHeight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                Console.WriteLine("Your score is: " + score);
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);
                Environment.Exit(0);
            }

            for (int i = 2; i < positions.Count(); i += 2)
            {
                if (head.xPos == positions[i] && head.yPos == positions[i + 1])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                    //???
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                    Console.WriteLine("Your score is: " + score);
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);
                    Environment.Exit(0);
                }
            }

            Thread.Sleep(250);
        }
    }
}





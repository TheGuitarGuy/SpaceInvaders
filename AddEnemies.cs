using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;
using Raylib_cs;

namespace cse210_batter_csharp
{
    public class AddEnemies : Action
    {
        private AudioService _audio = new AudioService();

        //Enemies are added on a set time interval with each wave getting progressively more difficult
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            //.05 difference allows for wave to be successful with current frame rate

            double time = Raylib.GetTime();
            Random randomNumber = new Random();
            if(time > 20 && time < 20.05)
            {
                cast["enemies1"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 10; i++)
                {
                    int randint = randomNumber.Next(1, 4);
                    int randomXVelocity = randomNumber.Next(-2,2);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 165;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 100;
                        enemy.SetVelocity(new Point(0, randomVelocity));
                    }
                }
            }
            else if (time > 30 && time < 30.05)
            {
                cast["enemies1"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 20; i++)
                {
                    int randomXVelocity = randomNumber.Next(-2,2);
                    int randint = randomNumber.Next(1, 4);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 165;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 100;
                        enemy.SetVelocity(new Point(0, randomVelocity));
                    }
                }
            }
            else if (time > 60 && time < 60.05)
            {
                cast["enemies2"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 20; i++)
                {
                    int randomXVelocity = randomNumber.Next(-4,4);
                    int randint = randomNumber.Next(1, 4);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 150;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 100;
                        enemy.SetVelocity(new Point(0, randomVelocity));
                    }
                }
            }
            else if (time > 90 && time < 90.05)
            {
                cast["enemies2"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 30; i++)
                {
                    int randomXVelocity = randomNumber.Next(-6,6);
                    int randint = randomNumber.Next(1, 4);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        int randomSpacing = randomNumber.Next(100, 200);
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += randomSpacing;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 100;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                }
            }
            else if (time > 120 && time < 120.05)
            {
                cast["enemies2"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                int randEnemies = randomNumber.Next(120, 150);
                for (int i = 0; i < randEnemies; i++)
                {
                    int randomXVelocity = randomNumber.Next(-6,6);
                    int randint = randomNumber.Next(1, 4);
                    int randomVelocity = randomNumber.Next(4, 16);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        int randomSpacing = randomNumber.Next(100, 300);
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += randomSpacing;
                        enemy.SetVelocity(new Point(randomXVelocity, randomVelocity));
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x_position, y_position);
                        cast["enemies"].Add(enemy);
                        x_position += 100;
                        enemy.SetVelocity(new Point(0, randomVelocity));
                    }
                }
            }
        }
    }
}
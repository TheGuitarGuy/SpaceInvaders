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
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {

            double time = Raylib.GetTime();
            Random randomNumber = new Random();

            // Bricks
            if(time > 10 && time <10.05)
            {
                cast["bricks"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 40; i++)
                {
                    int randint = randomNumber.Next(1,4);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        Brick brick = new Brick(x_position, y_position);
                        cast["bricks"].Add(brick);
                        x_position += 150;
                        brick.SetVelocity(new Point (0, randomVelocity));
                    }
                    else
                    {
                        Brick brick = new Brick(x_position, y_position);
                        cast["bricks"].Add(brick);
                        x_position += 100;
                        brick.SetVelocity(new Point (0, randomVelocity));
                    }
                }
            }
            else if(time > 30 && time < 30.05)
            {
                cast["bricks"] = new List<Actor>();
                int x_position = 5;
                int y_position = 0;
                for (int i = 0; i < 50; i++)
                {
                    int randint = randomNumber.Next(1,4);
                    int randomVelocity = randomNumber.Next(4, 12);
                    if (x_position > 800)
                    {
                        x_position = 5;
                        y_position += 50;
                    }
                    else if (randint == 4 || randint == 2 || randint == 3)
                    {
                        Brick brick = new Brick(x_position, y_position);
                        cast["bricks"].Add(brick);
                        x_position += 150;
                        brick.SetVelocity(new Point (0, randomVelocity));
                    }
                    else
                    {
                        Brick brick = new Brick(x_position, y_position);
                        cast["bricks"].Add(brick);
                        x_position += 100;
                        brick.SetVelocity(new Point (0, randomVelocity));
                    }
                }
            }
        }
    }
}
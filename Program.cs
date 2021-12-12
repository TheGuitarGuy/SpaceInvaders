using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;
using Raylib_cs; 

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();
            double time = Raylib.GetTime();
            Random randomNumber = new Random();

            // Bricks
            cast["bricks"] = new List<Actor>();
            int x_position = 5;
            int y_position = 0;
            for (int i = 0; i < 10; i++)
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
            
            // The Ball (or balls if desired)

            // TODO: Add your ball here

            // The paddle
            cast["paddle"] = new List<Actor>();
            cast["paddle"] = new List<Actor>();

            Paddle paddle = new Paddle(250, 550);
            cast["paddle"].Add(paddle);

            int shipPosition_x = paddle.GetX() -20;
            int shipPosition_y = paddle.GetY()-20;

            cast["lasers"] = new List<Actor>();
            Laser laser = new Laser(shipPosition_x, shipPosition_y);
            cast["lasers"].Add(laser);

            // TODO: Add your paddle here

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();


            // HandleOffScreen bill = new HandleOffScreen();
            // script["update"].Add(bill);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction action = new MoveActorsAction();
            script["update"].Add(action);
            // HandleCollisionsAction brickCollision = new HandleCollisionsAction();
            // script["update"].Add(brickCollision);
            ControlActorsAction movePaddle = new ControlActorsAction();
            script["input"].Add(movePaddle);
            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);
            HandleOffScreen collision = new HandleOffScreen();
            script["update"].Add(collision);
            HandleCollisionsAction collision1 = new HandleCollisionsAction();
            script["update"].Add(collision1);
            AddEnemies enemies = new AddEnemies();
            script["output"].Add(enemies);


            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Space Invaders", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
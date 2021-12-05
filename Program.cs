using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();
            

            // Bricks
            cast["bricks"] = new List<Actor>();
            int x_position = 5;
            int y_position = 0;
            for (int i = 0; i < 20; i++)
            {
                if (x_position > 800)
                {
                    x_position = 5;
                    y_position += 50;
                }
                else
                {
                    Brick brick = new Brick(x_position, y_position);
                    cast["bricks"].Add(brick);
                    x_position += 100;
                }
            }

            // The Ball (or balls if desired)

            // TODO: Add your ball here

            // The paddle
            cast["paddle"] = new List<Actor>();
            cast["paddle"] = new List<Actor>();

            Paddle paddle = new Paddle(Constants.PADDLE_X, Constants.PADDLE_Y);
            cast["paddle"].Add(paddle);

            int shipPosition_x = paddle.GetX();
            int shipPosition_y = paddle.GetY();

            cast["lasers"] = new List<Actor>();
            Laser laser = new Laser(shipPosition_x +20, shipPosition_y);
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

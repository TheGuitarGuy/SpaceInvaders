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

            // // Bricks
            // cast["bricks"] = new List<Actor>();
            // int x_position = 5;
            // int y_position = 0;
            // for (int i = 0; i < 100; i++)
            // {

            //     if (x_position > 800)
            //     {
            //         x_position = 5;
            //         y_position += 29;
            //     }
            //     else
            //     {
            //         Brick brick = new Brick(x_position, y_position);
            //         cast["bricks"].Add(brick);
            //         x_position += 53;
            //     }
            // }
            // cast["lazer"] = new List<Actor>();
            // Laser lazer = new Laser(200, 200);
            // cast["lazer"].Add(lazer);
            // for (int i = 0; i < 100; i++)
            // {

            //     if (x_position > 800)
            //     {
            //         x_position = 5;
            //         y_position += 29;
            //     }
            //     else
            //     {
            //         Laser l = new Laser(x_position, y_position);
            //         cast["lazer"].Add(l);
            //         x_position += 53;
            //     }
            // }

            // The Ball (or balls if desired)
            // cast["balls"] = new List<Actor>();
            // int x = 600;
            // int y = 500;
            // Ball ball = new Ball(x, y);
            // cast["balls"].Add(ball);

            // TODO: Add your ball here

            // The paddle
            cast["paddle"] = new List<Actor>();
            cast["paddle"] = new List<Actor>();

            Paddle paddle = new Paddle(Constants.PADDLE_X, Constants.PADDLE_Y);
            cast["paddle"].Add(paddle);


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
            // HandleOffScreen collision = new HandleOffScreen();
            // script["update"].Add(collision);
            // HandleCollisionsAction brickCollision = new HandleCollisionsAction();
            // script["update"].Add(brickCollision);
            ControlActorsAction movePaddle = new ControlActorsAction();
            script["input"].Add(movePaddle);
            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            
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

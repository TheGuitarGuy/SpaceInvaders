using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp
{
    public class HandleCollisionsAction : Action
    {

        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            // BounceLogic(cast);
            CollisionLogic(cast);
        }

        // private void BounceLogic(Dictionary<string, List<Actor>> cast)
        // {
        //     // Actor ball = cast["balls"][0];
        //     Actor paddle = cast["paddle"][0];

        //     // bool bounce = _physics.IsCollision(paddle, ball);
        //     var rand = new Random();
        //     int random = rand.Next(2);
        //     // if (bounce)
        //     // {
        //     //     _audio.PlaySound(Constants.SOUND_BOUNCE);

        //     //     Point reverseVelocity = ball.GetVelocity().Reverse();
        //     //     Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());

        //     //     ball.SetVelocity(newVelocity);
        //     // }
        //     // else if(bounce)
        //     // {
        //     //     _audio.PlaySound(Constants.SOUND_BOUNCE);

        //     //     // Point reverseVelocity = laser.GetVelocity().Reverse();
        //     //     // Point newVelocity = new Point(reverseVelocity.GetX(), reverseVelocity.GetY());

        //     //     // laser.SetVelocity(newVelocity);
        //     // }
        // }

        private void CollisionLogic(Dictionary<string, List<Actor>> cast)
        {
            // Actor brick = cast["bricks"][0];
            Actor paddle = cast["paddle"][0];
            Actor laser = cast["lasers"][0];
            List<Actor> bricks = cast["bricks"];

            Actor brickToRemove = null;
            int x_ship = paddle.GetX() +10;
            int y_ship = paddle.GetY();
            Random random = new Random();
            int randomNumber = random.Next(0,2);

            foreach (Actor brick in bricks)
            {
                bool endCollision = _physics.IsCollision(paddle, brick);
                bool collision = _physics.IsCollision(laser, brick);
                if (collision && randomNumber == 2)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    brickToRemove = brick;

                    Point reverseVelocity = laser.GetVelocity().Reverse();
                    laser.SetVelocity(new Point (0,0));
                    laser.SetImage(Constants.NULL_IMAGE);
                    laser.SetPosition(new Point (x_ship,y_ship));
                }
                else if (collision && randomNumber == 1)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    brickToRemove = brick;

                    Point reverseVelocity = laser.GetVelocity().Reverse();
                    laser.SetVelocity(new Point (0,0));
                    laser.SetImage(Constants.NULL_IMAGE);
                    laser.SetPosition(new Point (x_ship,y_ship));
                }
                else if (endCollision)
                {
                    _audio.PlaySound(Constants.SOUND_OVER);
                    paddle.SetImage(Constants.NULL_IMAGE);
                }
            }
            if (brickToRemove != null)
            {
                cast["bricks"].Remove(brickToRemove);
            }
        }
    }
}
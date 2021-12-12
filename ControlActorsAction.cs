using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;
using Raylib_cs;

namespace cse210_batter_csharp
{
    public class ControlActorsAction : Action
    {

        private PhysicsService _physics = new PhysicsService();
        private InputService _input = new InputService();


        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor paddle = cast["paddle"][0];
            if (_input.IsLeftPressed())
            {
                paddle.SetVelocity(new Point(Constants.PADDLE_SPEED * -1, 0));
            }

            else if (_input.IsRightPressed())
            {
                paddle.SetVelocity(new Point(Constants.PADDLE_SPEED, 0));
            }
            // else if(_input.IsUpPressed())
            // {
            //     paddle.SetVelocity(new Point(0,Constants.PADDLE_SPEED * -1));
            // }
            // else if(_input.IsDownPressed())
            // {
            //     paddle.SetVelocity(new Point(0, Constants.PADDLE_SPEED));
            // }
            else
            {
                paddle.SetVelocity(new Point(0, 0));
            }

            Actor laser = cast["lasers"][0];
            int y_laser = laser.GetY();
            int x_ship = paddle.GetX();
            int y_ship = paddle.GetY();
            
            if(_input.IsSpaceDown())
            {
                laser.SetVelocity(new Point(0, -40));
                int x = paddle.GetLeftEdge();
                int y = paddle.GetRightEdge();
                int z = paddle.GetBottomEdge();
                int w = paddle.GetTopEdge();
                int laser_x = y - x;
                int laser_y = z - w;
                cast["lasers"] = new List<Actor>();
                // int x = 600;
                // int y = 500;
                cast["lasers"].Add(laser);
                laser.SetImage(Constants.IMAGE_LASER);
            }
            else if(y_laser > 525)
            {
                laser.SetPosition(new Point (x_ship+20, y_ship+20));
                laser.SetVelocity(new Point (0,0));
                laser.SetImage(Constants.NULL_IMAGE);
            }
            
        }
    }
}
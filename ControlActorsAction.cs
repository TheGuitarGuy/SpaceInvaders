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
            //Controls ship x movement from left to right
            Actor ship = cast["ship"][0];
            if (_input.IsLeftPressed())
            {
                ship.SetVelocity(new Point(15 * -1, 0));
            }

            else if (_input.IsRightPressed())
            {
                ship.SetVelocity(new Point(15, 0));
            }
            else
            {
                ship.SetVelocity(new Point(0, 0));
            }

            Actor laser = cast["lasers"][0];
            int y_laser = laser.GetY();
            int x_ship = ship.GetX();
            int y_ship = ship.GetY();
            //Shows laser when space is pressed
            if(_input.IsSpaceDown())
            {
                laser.SetVelocity(new Point(0, -40));
                int x = ship.GetLeftEdge();
                int y = ship.GetRightEdge();
                int z = ship.GetBottomEdge();
                int w = ship.GetTopEdge();
                int laser_x = y - x;
                int laser_y = z - w;
                cast["lasers"] = new List<Actor>();
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
using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;
namespace cse210_batter_csharp
{
    public class HandleOffScreen : Action{
        PhysicsService _physicsService = new PhysicsService();
        Actor _topEdge = new Actor();
        Actor _bottomEdge = new Actor();
        Actor _leftEdge = new Actor();
        Actor _rightEdge = new Actor();
        Actor _brick = new Actor();

        public HandleOffScreen()
        {
            Casting.Point point = new Casting.Point(0, Constants.MAX_Y);
            _bottomEdge.SetWidth(Constants.MAX_X);
            _bottomEdge.SetPosition(point);

            point = new Casting.Point(0, 5);
            _topEdge.SetWidth(Constants.MAX_X);
            _topEdge.SetPosition(point);

            point = new Casting.Point(0,0);
            _leftEdge.SetHeight(Constants.MAX_Y);
            _leftEdge.SetPosition(point);
            
            point = new Casting.Point(Constants.MAX_X, 0);
            _rightEdge.SetHeight(Constants.MAX_Y);
            _rightEdge.SetPosition(point);
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor ball = cast["balls"][0];
            bool collision = _physicsService.IsCollision(ball, _rightEdge);
            if(collision)
            {
                Point reverseVelocity = ball.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX(), reverseVelocity.GetY() * -1);
                ball.SetVelocity(newVelocity);

            }
            collision = _physicsService.IsCollision(ball, _leftEdge);
            if(collision)
            {
                Point reverseVelocity = ball.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX() * -1, reverseVelocity.GetY());
                ball.SetVelocity(newVelocity);

            }
            collision = _physicsService.IsCollision(ball, _bottomEdge);
            if(collision)
            {
                Point reverseVelocity = ball.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX() * -1, reverseVelocity.GetY());
                ball.SetVelocity(newVelocity);

            }
            collision = _physicsService.IsCollision(ball, _topEdge);
            if(collision)
            {
                Point reverseVelocity = ball.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX() * -1, reverseVelocity.GetY());
                ball.SetVelocity(newVelocity);
            }
        }
    }
}
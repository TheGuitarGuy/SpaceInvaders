using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp
{
    public class HandleCollisionsAction : Action
    {
        public bool isOver = false;

        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            CollisionLogic(cast);
        }
        private bool CollisionLogic(Dictionary<string, List<Actor>> cast)
        {
            Actor ship = cast["ship"][0];
            Actor laser = cast["lasers"][0];
            List<Actor> enemies = cast["enemies"];

            Actor enemyToRemove = null;
            int x_ship = ship.GetX() +10;
            int y_ship = ship.GetY();
            Random random = new Random();
            int randomNumber = random.Next(0,2);
            //Check if laser collided with enemy
            foreach (Actor enemy in enemies)
            {
                bool endCollision = _physics.IsCollision(ship, enemy);
                bool collision = _physics.IsCollision(laser, enemy);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_EXPLODE);
                    enemyToRemove = enemy;
                    laser.SetVelocity(new Point (0,0));
                    laser.SetImage(Constants.NULL_IMAGE);
                    laser.SetPosition(new Point (x_ship,y_ship));
                }
                else if (endCollision)
                {
                    ship.SetHeight(0);
                    ship.SetWidth(0);
                    ship.SetImage(Constants.NULL_IMAGE);
                    enemy.SetImage(Constants.NULL_IMAGE);
                    _audio.PlaySound(Constants.SOUND_OVER);
                    laser.SetHeight(0);
                    laser.SetWidth(0);
                }
            }
            if (enemyToRemove != null)
            {
                cast["enemies"].Remove(enemyToRemove);
            }
            return isOver;
        }
    }
}
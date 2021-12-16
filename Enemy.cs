using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Enemy : Actor
    {
        public Enemy(int x, int y)
        {
            SetVelocity(new Point(0, 0));
            SetPosition(new Point(x, y));
            SetHeight(30);
            SetWidth(100);
            SetImage("Assets/enemy.png");
            GetImage();
        }
    }
}

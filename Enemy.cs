using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Brick : Actor
    {
        public Brick(int x, int y)
        {
            SetVelocity(new Point(0, 0));
            SetPosition(new Point(x, y));
            SetHeight(30);
            SetWidth(60);
            SetImage("Assets/alien.png");
            GetImage();
        }
    }
}

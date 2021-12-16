using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Ship : Actor
    {
        public Ship(int x, int y)
        {
            SetVelocity(new Point(0, 0));
            SetPosition(new Point(x, y));
            SetWidth(90);
            SetHeight(40);
            SetImage(Constants.IMAGE_SHIP);
            GetImage();
        }
    }
}
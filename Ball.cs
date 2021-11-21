using System;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Ball : Actor
    {
    public Ball(int x, int y)
    {
        SetVelocity(new Point(3, -20));
        SetPosition(new Point(x, y));
        SetHeight(Constants.BALL_HEIGHT);
        SetWidth(Constants.BALL_WIDTH);
        SetImage(Constants.IMAGE_BALL);
        GetImage();
    }
}
}
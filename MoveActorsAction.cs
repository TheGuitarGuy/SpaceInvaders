using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class MoveActorsAction : Action
    {
        //Moves the Actor
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
           foreach(List<Actor> group in cast.Values)
           {
               foreach(Actor actor in group)
               {
                   actor.MoveNext();
               }
           }
        }
    }
}

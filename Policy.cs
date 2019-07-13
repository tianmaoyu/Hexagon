using System;
using System.Collections.Generic;
using System.Text;

namespace Hexagon
{
    public class Policy
    {
        public static Hexagon GetHexagon(float px,float py)
        {
            return null;
        }

        public static Map GetMap()
        {
            return null;
        }

        public static List<Hexagon> GetAroundHexagon(Hexagon hexagon)
        {
            return null;
        }


        public static List<Hexagon> GetAroundHexagon(float px, float py)
        {
            return null;
        }

        public static List<Hexagon> InitMap()
        {
            var result = new List<Hexagon>();
            for(var y = 0; y < Config.Heigth_Count; y++)
            {
                for (var x = 0; x < Config.Width_Count; x++)
                {
                    var hexagon = new Hexagon();
                    hexagon.y = y;
                    hexagon.x = x;
                    result.Add(hexagon);
                }
            }
            return result;
        }

    }
}

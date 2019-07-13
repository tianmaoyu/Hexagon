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

        /// <summary>
        /// 得到周围相邻的的六边形
        /// </summary>
        /// <param name="hexagon"></param>
        /// <returns></returns>
        public static List<Hexagon> GetAroundHexagon(Hexagon hexagon)
        {
            //逆时针旋转，分别取各个相邻的，从12点，00点开始，2小时取一个边




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

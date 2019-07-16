using System;
using System.Collections.Generic;
using System.Linq;

namespace Hexagon
{
    public class Policy
    {
        public static Hexagon[,] Map;

        public static List<HexagonPoint> GetHexagonPoints()
        {
            var list = new List<HexagonPoint>();
           // var indexy=


            return list;
        }

        /// <summary>
        /// 根据一个地图的点，找到他所占的 六边形
        /// </summary>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <returns></returns>
        public static Hexagon GetHexagon(float px, float py)
        {
            var y= (py - Config.Hexagon_R) / 1.5f * Config.Hexagon_R;

            var y1 = (int)System.Math.Floor(y);
            var y2 = (int)System.Math.Ceiling(y);

            //偶数
            var x1 = (int) System.Math.Floor(px / Config.Hexagon_H / 2);
            //奇数
            var x2 = (int)System.Math.Floor((px- Config.Hexagon_H) / Config.Hexagon_H / 2);

            var list = new List<HexagonIndex>();
            list.Add(new HexagonIndex() { x = x1, y = y1 });
            list.Add(new HexagonIndex() { x = x1, y = y2 });
            list.Add(new HexagonIndex() { x = x2, y = y1 });
            list.Add(new HexagonIndex() { x = x2, y = y2 });
            //清理不存在的
            list.RemoveAll(i => i.x < 0 || i.y < 0 || i.x > Config.Width_Count || i.y > Config.Heigth_Count);

            var hexagonDistances = list.Select(item => {return Policy.Map[item.x, item.y];})
                                          .Select(i => new { Hexagon = i, Distance = Distance(px, py, i)});

            var hexagonDistance=hexagonDistances.Where(i => i.Distance == hexagonDistances.Min(j => j.Distance)).First();

            return hexagonDistance.Hexagon;
        }

        public static  float Distance(float px, float py, Hexagon hexagon)
        {
            var distance = Math.Sqrt((px - hexagon.x) * (px - hexagon.x) + (py - hexagon.y) * (py - hexagon.y));
            return (float)distance;
        }


        public static Map GetMap()
        {
            return null;
        }

        /// <summary>
        /// 得到周围相邻的的六边形
        /// 逆时针旋转，分别取各个相邻的，从12点开始，2小时取一个边
        /// </summary>
        /// <param name="hexagon"></param>
        /// <returns></returns>
        public static List<HexagonIndex> GetAroundHexagon(int x, int y)
        {
            var list = new List<HexagonIndex>();
            //偶然
            if (y % 2 == 0)
            {
                //1
                var hindex1 = new HexagonIndex();
                hindex1.x = x;
                hindex1.y = y + 1;
                list.Add(hindex1);
                //2
                var hindex2 = new HexagonIndex();
                hindex2.x = x + 1;
                hindex2.y = y;
                list.Add(hindex2);
                //3
                var hindex3 = new HexagonIndex();
                hindex3.x = x;
                hindex3.y = y - 1;
                list.Add(hindex3);
                //4
                var hindex4 = new HexagonIndex();
                hindex4.x = x - 1;
                hindex4.y = y - 1;
                list.Add(hindex4);
                //5
                var hindex5 = new HexagonIndex();
                hindex5.x = x - 1;
                hindex5.y = y;
                list.Add(hindex5);
                //6
                var hindex6 = new HexagonIndex();
                hindex6.x = x - 1;
                hindex6.y = y + 1;
                list.Add(hindex6);
            }
            else ///奇数
            {
                //1
                var hindex1 = new HexagonIndex();
                hindex1.x = x + 1;
                hindex1.y = y + 1;
                list.Add(hindex1);
                //2
                var hindex2 = new HexagonIndex();
                hindex2.x = x + 1;
                hindex2.y = y;
                list.Add(hindex2);
                //3
                var hindex3 = new HexagonIndex();
                hindex3.x = x + 1;
                hindex3.y = y - 1;
                list.Add(hindex3);
                //4
                var hindex4 = new HexagonIndex();
                hindex4.x = x;
                hindex4.y = y - 1;
                list.Add(hindex4);
                //5
                var hindex5 = new HexagonIndex();
                hindex5.x = x - 1;
                hindex5.y = y + 1;
                list.Add(hindex5);
                //6
                var hindex6 = new HexagonIndex();
                hindex6.x = x;
                hindex6.y = y + 1;
                list.Add(hindex6);
            }
            //清理不存在的
            list.RemoveAll(i => i.x < 0 || i.y < 0 || i.x > Config.Width_Count || i.y > Config.Heigth_Count);
            return list;
        }

        public static List<Hexagon> GetAroundHexagon(float px, float py)
        {
            return null;
        }

        public static List<Hexagon> InitMap()
        {
            var result = new List<Hexagon>();
            for (var y = 0; y < Config.Heigth_Count; y++)
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

        /// <summary>
        /// 二维数组
        /// </summary>
        /// <returns></returns>
        public static Hexagon[,] InitMapArray()
        {
            var hexagons = new Hexagon[Config.Width_Count, Config.Heigth_Count];
            for (var y = 0; y < Config.Heigth_Count; y++)
            {
                for (var x = 0; x < Config.Width_Count; x++)
                {
                    var hexagon = new Hexagon();
                    hexagon.y = y;
                    hexagon.x = x;
                    hexagons[x,y] = hexagon;
                }
            }
            return hexagons;
        }

    }
}
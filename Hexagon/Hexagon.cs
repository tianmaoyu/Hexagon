using System;
using System.Collections.Generic;
using System.Text;

namespace Hexagon
{
    /// <summary>
    /// 正六边形
    /// </summary>
    public class Hexagon
    {
        /// <summary>
        /// 地图坐标
        /// </summary>
        public float px
        {
            get
            {
                //偶数
                if (this.x % 2 == 0)
                {
                    return Config.Hexagon_H * (this.x * 2 + 1);
                }
                //奇数
                else
                {
                    return 2 * Config.Hexagon_H * (this.x + 1);
                }
            }
        }

        public float py
        {
            get
            {
                return Config.Hexagon_R*(this.y * 1.5f + 1);
            }
        }

        /// <summary>
        /// 索引坐标
        /// </summary>
        public int x { get; set; }
        public int y { get; set; }


    }


}

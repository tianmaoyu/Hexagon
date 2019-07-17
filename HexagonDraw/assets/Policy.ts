import { HexagonIndex } from "./HexagonIndex";
import { Config } from "./Config";
import { Hexagon } from "./Hexagon";

export class Policy {

    // / <summary>
    // / 根据一个地图的点，找到他所占的 六边形
    // / </summary>
    // / <param name="px"></param>
    // / <param name="py"></param>
    // / <returns></returns>
    public static  GetHexagon(px,  py):HexagonIndex {
        var y = (py - Config.Hexagon_R) / (1.5 * Config.Hexagon_R);

        var y1 =Math.floor(y);
        var y2 = Math.ceil(y);

        //偶数
        var x1 =  Math.floor(px / Config.Hexagon_H / 2);
        //奇数
        var x2 = Math.floor((px - Config.Hexagon_H) / Config.Hexagon_H / 2);

        var list = new Array<HexagonIndex>();
        var index1=new HexagonIndex();index1.x=x1;index1.y=y1;
        list.push(index1);
        var index2=new HexagonIndex();index2.x=x1;index2.y=y2;
        list.push(index2);
        var index3=new HexagonIndex();index3.x=x2;index3.y=y1;
        list.push(index3);
        var index4=new HexagonIndex();index4.x=x2;index4.y=y2;
        list.push(index4);
        
        //清理不存在的
        var _list = list.filter(i => i.x >= 0 && i.y >= 0 && i.x <= Config.Width_Count && i.y <= Config.Heigth_Count);

        //直接结算,如果到到圆心的距离，小于H，就是它
        //大于 R 的直接扔掉
        for(var item of _list){
            var distance=  this.Distance(px,py,item);
            if(distance<=Config.Hexagon_H){
                return item;
            }
        }
         //如果在 H-R 之间的 
        for(var item of _list){
            var distance=  this.Distance(px,py,item);
            if(distance<=Config.Hexagon_R){
                return item;
            }
        }
    }

    public static Distance(px, py, index: HexagonIndex): number {
        
        var hexagon=new Hexagon();
        hexagon.x=index.x;
        hexagon.y=index.y;
        var distance = Math.sqrt((px - hexagon.getPx()) * (px - hexagon.getPx()) + (py - hexagon.getPy()) * (py - hexagon.getPy()));
        return distance;
    }




    /// <summary>
    /// 得到周围相邻的的六边形
    /// 逆时针旋转，分别取各个相邻的，从12点开始，2小时取一个边
    /// </summary>
    /// <param name="hexagon"></param>
    /// <returns></returns>
    public static GetAroundHexagon(x: number, y: number): Array<HexagonIndex> {
        var list = new Array<HexagonIndex>();
        //偶然
        if (y % 2 == 0) {
            //1
            var hindex1 = new HexagonIndex();
            hindex1.x = x;
            hindex1.y = y + 1;
            list.push(hindex1);
            //2
            var hindex2 = new HexagonIndex();
            hindex2.x = x + 1;
            hindex2.y = y;
            list.push(hindex2);
            //3
            var hindex3 = new HexagonIndex();
            hindex3.x = x;
            hindex3.y = y - 1;
            list.push(hindex3);
            //4
            var hindex4 = new HexagonIndex();
            hindex4.x = x - 1;
            hindex4.y = y - 1;
            list.push(hindex4);
            //5
            var hindex5 = new HexagonIndex();
            hindex5.x = x - 1;
            hindex5.y = y;
            list.push(hindex5);
            //6
            var hindex6 = new HexagonIndex();
            hindex6.x = x - 1;
            hindex6.y = y + 1;
            list.push(hindex6);
        }
        else ///奇数
        {
            //1
            var hindex1 = new HexagonIndex();
            hindex1.x = x + 1;
            hindex1.y = y + 1;
            list.push(hindex1);
            //2
            var hindex2 = new HexagonIndex();
            hindex2.x = x + 1;
            hindex2.y = y;
            list.push(hindex2);
            //3
            var hindex3 = new HexagonIndex();
            hindex3.x = x + 1;
            hindex3.y = y - 1;
            list.push(hindex3);
            //4
            var hindex4 = new HexagonIndex();
            hindex4.x = x;
            hindex4.y = y - 1;
            list.push(hindex4);
            //5
            var hindex5 = new HexagonIndex();
            hindex5.x = x - 1;
            hindex5.y = y + 1;
            list.push(hindex5);
            //6
            var hindex6 = new HexagonIndex();
            hindex6.x = x;
            hindex6.y = y + 1;
            list.push(hindex6);
        }
        //清理不存在的
        var _list = list.filter(i => i.x >= 0 && i.y >= 0 && i.x <= Config.Width_Count && i.y <= Config.Heigth_Count);
        return _list;
    }


    public static InitMap():Array<Hexagon> {
        var result = new Array<Hexagon>();
        for (var y = 0; y < Config.Heigth_Count; y++) {
            for (var x = 0; x < Config.Width_Count; x++) {
                var hexagon = new Hexagon();
                hexagon.x = x;
                hexagon.y = y;
                result.push(hexagon);
            }
        }
        return result;
    }

    /// <summary>
    /// 二维数组
    /// </summary>
    /// <returns></returns>
    public static  InitMapArray() {
        var hexagons = [];
        for (var y = 0; y < Config.Heigth_Count; y++) {
            for (var x = 0; x < Config.Width_Count; x++) {
                var hexagon = new Hexagon();
                hexagon.y = y;
                hexagon.x = x;
                hexagons[x][y] = hexagon;
            }
        }
        return hexagons;
    }

}
import { Config } from "./Config";


/// <summary>
/// 正六边形
/// </summary>
export class Hexagon {

    public x: number;
    public y: number;

    public getPx() {
        if (this.y % 2 == 0) {
            return Config.Hexagon_H * (this.x * 2 + 1);
        }
        //奇数
        else {
            return 2 * Config.Hexagon_H * (this.x + 1);
        }
    }
    public getPy() {
        return Config.Hexagon_R * (this.y * 1.5 + 1);
    }

}
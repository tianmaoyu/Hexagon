import { Policy } from "./Policy";
import { Hexagon } from "./Hexagon";
import { Config } from "./Config";


const { ccclass, property } = cc._decorator;

@ccclass
export default class Draw extends cc.Component {

    private r: number =100;
    private h: number = this.r*0.668;
    private heigthCount: number = 10;
    private widthCount: number = 10;

    // use this for initialization
    onLoad() {
        var canvasNode= cc.find("Canvas");

        canvasNode.on(cc.Node.EventType.TOUCH_START,this.onClick,this);
        // this.doawCoordinate();
        this.doawAllHexgon();
        // ctx.moveTo(0,0);
        // ctx.lineTo(0,100);
        // ctx.moveTo(0,0);
        // ctx.lineTo(100,0);
        // ctx.stroke();
    }

    private onClick(event :cc.Event.EventTouch){
        var x= event.getLocationX();
        var y= event.getLocationY();
        var ctx = this.getComponent(cc.Graphics);
        ctx.strokeColor = ctx.strokeColor.fromHEX('#0000ff');
        ctx.circle(x,y,2);
        ctx.stroke();
        cc.log(x,y);
        var hexagonIndex= Policy.GetHexagon(x,y);
        cc.log("hexagonIndex:("+hexagonIndex.x+":"+hexagonIndex.y+")");
    }

    //坐标
    doawCoordinate() {
        var ctx = this.getComponent(cc.Graphics);
        ctx.moveTo(0, 0);
        //y 轴
        for (var i = 0; i < this.heigthCount; i++) {
            var x = i *  this.h + this.h;
            ctx.moveTo(x, 0);
            ctx.lineTo(x, 640);
            ctx.stroke();
        }

        //x 轴
        for (var i = 0; i < this.widthCount; i++) {
            var y = this.r*(i * 1.5 + 1);;
            ctx.moveTo(0, y);
            ctx.lineTo(1280,y );
            ctx.stroke();
        }
    }

    public doawAllHexgon(){
        var listHexgon=Policy.InitMap();
        debugger;
        // this.doawHexgon(listHexgon[0])
        // this.doawHexgon(listHexgon[1])
        for(var item of listHexgon){
            this.doawHexgon(item)
        }

    }

    private doawHexgon(hexagon:Hexagon){
        var ctx = this.getComponent(cc.Graphics);
          var px=hexagon.getPx();
          var py=hexagon.getPy();
          
          //一边
          var ex0=px;
          var ey0=py+Config.Hexagon_R;
          ctx.moveTo(ex0, ey0);

          var ex1=px+ Config.Hexagon_H;
          var ey1=py+Config.Hexagon_R/2;
          ctx.lineTo(ex1,ey1 );


          //2边
          var ex2=px+ Config.Hexagon_H;
          var ey2=py-Config.Hexagon_R/2;
          ctx.lineTo(ex2,ey2 );

           //3边
           var ex3=px;
           var ey3=py-Config.Hexagon_R;
           ctx.lineTo(ex3,ey3 );
           //4边
           var ex4=px-Config.Hexagon_H;
           var ey4=py-Config.Hexagon_R/2;
           ctx.lineTo(ex4,ey4 );

           //5
           var ex5=px-Config.Hexagon_H;
           var ey5=py+Config.Hexagon_R/2;
           ctx.lineTo(ex5,ey5);

           ctx.lineTo(ex0,ey0);
        //    ctx.strokeColor.fromHEX("#ff0000")
           ctx.circle(px,py,Config.Hexagon_H);
        //    ctx.strokeColor.fromHEX("#0006ff")
           ctx.circle(px,py,Config.Hexagon_R);
        //    ctx.strokeColor.fromHEX("#000000")
           ctx.stroke();

    }

}

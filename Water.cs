using System;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;
namespace daltonsautomata
{
    public class Water:BaseCell
    {
        Random r = new Random();
        public Water()
        {
            base.cellType = 2;
            base.stateOfMatter = 2;
            base.cellColor = Color.BLUE;
            base.nextCellPositions.Add(new Vector2(0,1));
            base.nextCellPositions.Add(new Vector2(0,2));
            base.nextCellPositions.Add(new Vector2(3,0));
            base.nextCellPositions.Add(new Vector2(-3,0));
            base.nextCellPositions.Add(new Vector2(1,0));
            base.nextCellPositions.Add(new Vector2(-1,0));
        }

        public override void UpdateCell(short x, short y, ref short[,,] cellGrid, ref bool[,] blacklist)
        {
           
                        base.UpdateCell(x,y,ref cellGrid,ref blacklist);
        }
    }
}

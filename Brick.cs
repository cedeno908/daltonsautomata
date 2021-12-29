using System;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace daltonsautomata
{
    public class Brick:BaseCell
    {
        public Brick()
        {
            base.cellType = 3;
            base.stateOfMatter = 3;//3 means solid
            base.cellColor = Color.RED;
            base.nextCellPositions.Add(new System.Numerics.Vector2(0,0));
        }
        public override void UpdateCell(short x, short y, ref short[,,] cellGrid, ref bool[,] blacklist)
        {
            base.UpdateCell(x,y,ref cellGrid, ref blacklist);
        }
    }
}

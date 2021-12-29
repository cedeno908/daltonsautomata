using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Color;
namespace daltonsautomata
{
    public class Sand : BaseCell
    {
        
        Random r = new Random();
        public Sand()
        {
            base.cellType = 1;
            base.stateOfMatter = 3;
            base.cellColor = new Color(255, 255, 50, 255);
            base.nextCellPositions.Add(new Vector2(0,1));
            base.nextCellPositions.Add(new Vector2(0,2));
            base.nextCellPositions.Add(new Vector2(1,1));
            base.nextCellPositions.Add(new Vector2(-1,1));
        }
        public override void UpdateCell(short x, short y, ref short[,,] cellGrid, ref bool[,] blacklist)
        { 
            base.UpdateCell(x, y, ref cellGrid, ref blacklist);

            
            
            
        }

    }
}

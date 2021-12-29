using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
namespace daltonsautomata
{

    //cell manager
    public class Cell
    {

        Sand sand = new Sand();
        Water water = new Water();
        Brick brick = new Brick();

        public Cell()
        {

        }

        public void UpdateCellGrid(ref short[,,] cellGrid)
        {

            //ignore these tiles, they were updated already
            bool[,] blacklist = new bool[cellGrid.GetLength(0), cellGrid.GetLength(1)];
            for (short x = 0; x < cellGrid.GetLength(0) - 1; x++)
            {
                for (short y = 0; y < cellGrid.GetLength(1) - 1; y++)
                {   if(cellGrid[x,y,0] == 0){
                        continue;
                    }
                    if (blacklist[x, y] == true)
                    {
                        continue;
                    }
                 

                    sand.UpdateCell(x, y, ref cellGrid, ref blacklist);
                    water.UpdateCell(x, y, ref cellGrid, ref blacklist);
                    brick.UpdateCell(x, y, ref cellGrid, ref blacklist);
                    

                    if(cellGrid[x,y,0] == 69)
                    {
                        blacklist[x, y] = true;
                        cellGrid[x, y,0] = 0;
                    }

                }
            }
        }

        public void AddCell(short x, short y, ref short[,,] cellGrid, short cellType){
            if(cellGrid[x,y,0] == 0){
                cellGrid[x,y,0] = cellType;
                cellGrid[x,y,1] = 1;
            }
        }
    
    }
}

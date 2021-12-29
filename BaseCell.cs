using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
namespace daltonsautomata
{
    //base cell for all cells to inherit from. cell.cs is just a cell manager
    public class BaseCell
    {

        public short cellType;//0 air, 1 sand, 2 water, etc.

        public List<Vector2> nextCellPositions = new List<Vector2>();

        public Color cellColor;

        public float tickCounter;
        public short stateOfMatter = 0;//3 is solid, 2 is liquid, 1 is gas
     
public int chunkVelocity;

        public virtual void UpdateCell(short x, short y, ref short[,,] cellGrid, ref bool[,] blacklist)
        {
            chunkVelocity = 0;
            //a coounter for things that will not happen every frame
            tickCounter+=GetFrameTime();


            if (cellGrid[x, y,0] == cellType)
            {
                if(y < cellGrid.GetLength(1) - 5 && y> 5 && x < cellGrid.GetLength(0) - 25 && x > 25){
                    DrawPixel(x, y, cellColor);
                foreach(Vector2 nextPosition in nextCellPositions){
                    if(cellGrid[x + (short)nextPosition.X, y+(short)nextPosition.Y,2] < stateOfMatter && blacklist[x + (short)nextPosition.X, y+(short)nextPosition.Y] == false){
            
                        //loop though all the cells
                        for(short Xlerp = 0; Xlerp <= nextPosition.X; Xlerp++){
                            for(short Ylerp = 0; Ylerp <= nextPosition.Y; Ylerp++){
                                //check if a high velocity cell will clip through other cells
        
                                if(cellGrid[x + Xlerp, y+Ylerp,0] == 0 ||cellGrid[x+Xlerp,y+Ylerp,1] != 0|| blacklist[x+Xlerp, y+Ylerp] == false){
                                    continue;
                                }
                                else{
                                    return;
                                }
                            }
                        }

                    
if(tickCounter >= 0.15f){
                        Gravity(x,y,ref cellGrid);
                       tickCounter = 0f;

                    }

if(cellGrid[x + (short)nextPosition.X, y+(short)nextPosition.Y,2] < stateOfMatter){

                        cellGrid[x,y,0] = cellGrid[x + (short)nextPosition.X, y+(short)nextPosition.Y,0]; 
                        cellGrid[x + (short)nextPosition.X, y+(short)nextPosition.Y,0] = cellType;
}
else{

                        cellGrid[x,y,0] = 0; 
}

                        cellGrid[x,y,2] = 0;
                        try{
                        blacklist[x + (short)nextPosition.X * cellGrid[x,y,1],y+(short)nextPosition.Y * cellGrid[x,y,1]] = true;
                        
                        cellGrid[x + (short)nextPosition.X,y+(short)nextPosition.Y,0] = cellType;
                        }
                        catch{
                            
                        }
                        chunkVelocity += cellGrid[x,y,1];
                        cellGrid[x + (short)nextPosition.X,y+(short)nextPosition.Y,2] = stateOfMatter;

                        return;
                        
                    }
                 
                   
                }

                

            }

        }

       
    }
    

    //does a chunk have greater than 1 velocity
    public bool ChunkG1V(){
        if(chunkVelocity != 0){
            return true;
        }
        else{
            return false;
        }
    }
     public void Gravity(short x, short y, ref short[,,] cellGrid){

                foreach(Vector2 nextPosition in nextCellPositions){

                    if(cellGrid[x + (short)nextPosition.X, y+(short)nextPosition.Y,2] > stateOfMatter){

                        cellGrid[x,y,1] = 0;
                    }
             if(cellGrid[x,y,+1] < 5){
                        cellGrid[x,y,1] += 1;
                        }
                        cellGrid[x + (short)nextPosition.X,y+(short)nextPosition.Y,1] = cellGrid[x,y,1];
                        cellGrid[x,y,1] = 0;

                        
                }

                
        }
    }
}

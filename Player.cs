using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace daltonsautomata
{
    public class Player
    {
        public Player()
        {
        }

        public short height = 15;
        public short width = 10;
        public Vector2 position = new Vector2(50,50);
        //positionIntertia only works on y axis
        public Vector2 positionInertia = new Vector2(0,0);
        //todo: add velocity

        public void PlayerCollision(ref short[,,] cellGrid)
        {

            if(position.Y > cellGrid.GetLength(1) - 30){
                position.Y--;
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    DrawRectangle((int)position.X+x - 5, (int)position.Y + y, 3, 3, Color.ORANGE);
                   
                    
                }
            }
                if (cellGrid[(int)position.X, (int)position.Y + height,0] == 0|| cellGrid[(int)position.X, (int)position.Y + height,0] == 2 || cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                {
                if(position.Y < GetScreenHeight()-15 && positionInertia == new Vector2(0,0))
                    position.Y += 2;
                }

          

            if (cellGrid[(int)position.X + width / 2 + 1, (int)position.Y,0] == 0 || cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
            {
            }
            else
            {
                position.X -= 1;
            }
            if (cellGrid[(int)position.X - width / 2 - 1, (int)position.Y,0] == 0 || cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
            { }
            else
            {
                position.X += 1;
            }
                if (IsKeyDown(KeyboardKey.KEY_D))
            {
                if (cellGrid[(int)position.X + width + 1, (int)position.Y + height,0] == 0|| cellGrid[(int)position.X, (int)position.Y + height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                {
                    if (cellGrid[(int)position.X +  width/2+1, (int)position.Y,0] == 0 || cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)

                    {
                        position.X += 1;
                    }
                }
                else
                {
                    

                        position.Y -= 1;
                        position.X += 1;
                    
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                if (cellGrid[(int)position.X - width - 1, (int)position.Y + height,0] == 0|| cellGrid[(int)position.X, (int)position.Y + height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                {
                    if (cellGrid[(int)position.X -width/2- 1, (int)position.Y,0] == 0|| cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2|| cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                    {
                        position.X -= 1;
                    }
                }
                else
                {
                   
                        position.Y -= 1;
                        position.X -= 1;
                    
                    
                }
            }

            if(positionInertia != new Vector2(0, 0))
            {
                if (cellGrid[(int)position.X + width / 2 + 1, (int)position.Y,0] == 0 || cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2 || cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                {
                }
                else
                {
                    positionInertia.Y = 0;
                    position.Y += 5;
                }
                if (cellGrid[(int)position.X - width / 2 - 1, (int)position.Y,0] == 0 || cellGrid[(int)position.X + width / 2 + 1, (int)position.Y - height,0] == 2 || cellGrid[(int)position.X, (int)position.Y + height,0] == 69)
                { }
                else
                {
                    positionInertia.Y = 0;
                    position.Y += 5;
                }
                position.Y -= 3;
                if(positionInertia.Y < 0)
                {
                    positionInertia.Y++;
                }
                else
                {
                    positionInertia.Y--;
                }
            }

           
            if (IsKeyDown(KeyboardKey.KEY_SPACE) || IsKeyDown(KeyboardKey.KEY_W))
            {
                if(cellGrid[(int)position.X, (int)position.Y + height,0] != 0)
                {
                    positionInertia.Y = 10;
                }
            }
           
        }
        }
    }


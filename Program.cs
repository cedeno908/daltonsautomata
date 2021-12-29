using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
namespace daltonsautomata
{
    class Program
    {
        const int screenWidth = 500;
        const int screenHeight = 300;

        

        static void Main()
        {
            Cell aCell = new Cell();
            Player player = new Player();
            short[,,] cellGrid = new short[screenWidth, screenHeight + 5,3];//0th dimension is the cell types, 1st is the cell velocity, 2nd dimension is the cell's state of matter
           
            InitWindow(screenWidth, screenHeight, "Dalton's Automata");



            int brushSize = 7;
            SetTargetFPS(50);
            while (!WindowShouldClose())
            {

             
                if (IsKeyPressed(KeyboardKey.KEY_UP) && brushSize <= 15)
                {
                    brushSize += 2;
                }
                if (IsKeyPressed(KeyboardKey.KEY_DOWN) && brushSize >= 3)
                {
                    brushSize -= 2;
                }
                if (IsKeyDown(KeyboardKey.KEY_F))
                {
                    if (GetMousePosition().X < screenWidth - brushSize && GetMousePosition().X > 1 + brushSize && GetMousePosition().Y < screenHeight - brushSize && GetMousePosition().Y > 1)
                    {

                        for(int x = 0; x < brushSize; x++)
                        {
                            for (int y = 0; y < brushSize; y++)
                            {

                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y + y,0] = 1;
                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y +y ,1] = 1;
                            }
                        }
                    }
                }
                if (IsKeyDown(KeyboardKey.KEY_L))
                {
                    if (GetMousePosition().X < screenWidth- brushSize && GetMousePosition().X > 1+ brushSize && GetMousePosition().Y < screenHeight - brushSize && GetMousePosition().Y > 1)
                    {
                        for (int x = 0; x < brushSize; x++)
                        {
                            for (int y = 0; y < brushSize; y++)
                            {
                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y + y,0] = 2;
                            }
                        }
                    }
                }
                if (IsKeyDown(KeyboardKey.KEY_B))
                {
                    if (GetMousePosition().X < screenWidth- brushSize && GetMousePosition().X > 1+ brushSize && GetMousePosition().Y < screenHeight -brushSize&&GetMousePosition().Y > 1)
                    {
                        for (int x = 0; x < brushSize; x++)
                        {
                            for (int y = 0; y < brushSize; y++)
                            {
                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y + y,0] = 3;
                            }
                        }
                    }
                }
                if (IsKeyDown(KeyboardKey.KEY_E))
                {
                    if (GetMousePosition().X < screenWidth- brushSize && GetMousePosition().X > 1+ brushSize && GetMousePosition().Y < screenHeight - brushSize && GetMousePosition().Y > 1)
                    {

                        for (int x = 0; x < brushSize; x++)
                        {
                            for (int y = 0; y < brushSize; y++)
                            {
                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y + y,2] = 0;
                                cellGrid[(int)GetMousePosition().X + x, (int)GetMousePosition().Y + y,0] = 0;
                            }
                        }
                    }

                }
               
                    BeginDrawing();
                

                ClearBackground(LIGHTGRAY);
                //aCell.DrawCellGrid(cellGrid);

                //player.PlayerCollision(ref cellGrid);
                aCell.UpdateCellGrid(ref cellGrid);

                EndDrawing();
            }

            CloseWindow();
        }
    }
}

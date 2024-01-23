using System;
using System.Dynamic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(1920, 1080, "Hello");
        // Raylib.ToggleFullscreen();
        Raylib.SetTargetFPS(60);
        int playerradius = 25;
        int player1x = 150;
        int player1y = 150;
        int player1height = playerradius;
        int player1width = playerradius;
        int enemyx = 1300;
        int enemyy = 150;
        int point1xpos = 300;
        int point1ypos = 885;
        int point2xpos = 1000;
        int point2ypos = 135;
        int point3xpos = 1600;
        int point3ypos = 450;
        int pointwidth = 25;
        int pointheight = 25;


        bool movement = true;
        bool scenestart = true;
        bool scenegame1 = false;
        bool scenegame2 = false;
        bool Gameover = false;
        bool blockmove = false;
        string starttext = "Press SPACE to start!";
        string dnt = "Do not touch the walls!";
        string gm = "GAME OVER";
        string res = "Press enter to restart";
        string end = "Press ESC to exit";
        int pointamount = 0;
        int levelamount = 1;
        string pointcount = "Points: ";
        string currentlevel = "Level ";
        float enemyradius = 50;

        int blockxpos = 600;
        int blockypos = 850;
        int blockwidth = 30;
        int blockheight = 30;



        float levelradius2 = 2500;
        int[,] grid1 = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1},
            {1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,1},
            {1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,1},
            {1,0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,0,0,0,1,1,1},
            {1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,1,1,0,0,0,1,1,1},
            {1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,1,1,0,0,0,1,1,1},
            {1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,0,0,0,1,1,1},
            {1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,0,0,0,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        int tileSize = 75;

        List<Rectangle> walls = new();

        for (int x = 0; x < grid1.GetLength(1); x++)
        {
            for (int y = 0; y < grid1.GetLength(0); y++)
            {
                // System.Console.WriteLine($"x: {x}, y: {y}");
                if (grid1[y, x] == 1)
                {
                    Rectangle wall = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
                    walls.Add(wall);
                }
            }
        }



        while (!Raylib.WindowShouldClose())
        {


            while (scenestart)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);
                Raylib.DrawText(starttext, 600, 500, 60, Color.BLACK);
                Raylib.DrawText(dnt, 700, 800, 40, Color.BLACK);
                Raylib.EndDrawing();

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    scenestart = false;
                    scenegame1 = true;
                }
            }

            while (scenegame1)
            {

                Vector2 enemycenter = new Vector2(enemyx, enemyy);
                Vector2 playercenter = new Vector2(player1x, player1y);
                Vector2 point1center = new Vector2(point1xpos, point1ypos);
                Vector2 point2center = new Vector2(point2xpos, point2ypos);
                Vector2 point3center = new Vector2(point3xpos, point3ypos);

                Vector2 Playernextposition = new Vector2(player1x, player1y);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKGRAY);

                blockmove = true;



                foreach (Rectangle wall in walls)
                {
                    Raylib.DrawRectangleRec(wall, Color.RED);
                }



                foreach (Rectangle wall in walls)
                {
                    bool collision = Raylib.CheckCollisionCircleRec(playercenter, playerradius, wall);

                    if (collision == true)
                    {
                        scenegame1 = false;
                        Gameover = true;
                    }
                }


                if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && movement == true)
                {
                    player1x += 6;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && movement == true)
                {
                    player1x -= 6;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && movement == true)
                {
                    player1y += 6;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && movement == true)
                {
                    player1y -= 6;
                }


                //Rectangle playerRect = new Rectangle(player1x, player1y, player1width, player1height);
                //Rectangle enemyRect = new Rectangle(enemyx, enemyy, goalexpandx, goalexpandy);
                Rectangle point1 = new Rectangle(point1xpos, point1ypos, pointwidth, pointheight);
                Rectangle point2 = new Rectangle(point2xpos, point2ypos, pointwidth, pointheight);
                Rectangle point3 = new Rectangle(point3xpos, point3ypos, pointwidth, pointheight);
                Rectangle block = new Rectangle(blockxpos, blockypos, blockwidth, blockheight);

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                {
                    return;
                }

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_HOME))
                {
                    scenegame1 = false;
                    scenegame2 = true;
                }



                bool areOverlapping1 = Raylib.CheckCollisionCircles(playercenter, playerradius, enemycenter, enemyradius);
                bool areOverlapping2 = Raylib.CheckCollisionCircleRec(playercenter, playerradius, point1);
                bool areOverlapping3 = Raylib.CheckCollisionCircleRec(playercenter, playerradius, point2);
                bool areOverlapping4 = Raylib.CheckCollisionCircleRec(playercenter, playerradius, point3);




                Raylib.DrawCircleV(playercenter, playerradius, Color.BLUE);
                Raylib.DrawCircleV(enemycenter, enemyradius, Color.PURPLE);




                if (areOverlapping1 == true)
                {

                    enemyradius += 50;


                    pointamount = 0;

                    if (enemyradius > 2500)
                    {
                        scenegame1 = false;
                        scenegame2 = true;

                    }
                    if (levelamount < 2)
                    {
                        levelamount += 1;
                    }

                }
                if (areOverlapping2 == true)
                {
                    point1xpos = -2000;
                    pointamount += 1;
                    Console.Beep(500, 200);
                }
                if (areOverlapping3 == true)
                {
                    point2xpos = -2100;
                    pointamount += 1;
                    Console.Beep(500, 200);
                }
                if (areOverlapping4 == true)
                {
                    point3xpos = 2200;
                    pointamount += 1;
                    Console.Beep(500, 200);
                }




                Raylib.DrawRectangleRec(point1, Color.GREEN);
                Raylib.DrawRectangleRec(point2, Color.GREEN);
                Raylib.DrawRectangleRec(point3, Color.GREEN);
                Raylib.DrawRectangleRec(block, Color.BLACK);



                Raylib.DrawText(pointcount + pointamount + "/3", 50, 50, 40, Color.WHITE);
                Raylib.DrawText(currentlevel + levelamount, 900, 50, 40, Color.WHITE);

                Raylib.EndDrawing();

            }

            while (scenegame2)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKGRAY);
                Raylib.DrawCircle(player1x, player1y, levelradius2, Color.PURPLE);
                if (scenegame2 == true)
                {
                    levelradius2 -= 50;
                }
                Vector2 enemycenter = new Vector2(enemyx, enemyy);
                Vector2 playercenter = new Vector2(player1x, player1y);


                //Rectangle playerRect = new Rectangle(player1x, player1y, player1width, player1height);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    player1x += 8;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    player1x -= 8;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    player1y += 8;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    player1y -= 8;
                }

                if (player1x > 1810)
                {
                    player1x -= 8;
                }
                if (player1x < 5)
                {
                    player1x += 8;
                }
                if (player1y > 965)
                {
                    player1y -= 8;
                }
                if (player1y < 10)
                {
                    player1y += 8;
                }

                int attackerxpos = Random.Shared.Next(100, 1800);
                int attackerypos = 100;

                

                Raylib.DrawRectangle(attackerxpos, attackerypos, 25, 25, Color.BLACK);

                attackerypos += 4;





                // Raylib.DrawRectangleRec(playerRect, Color.BLACK);
                Raylib.DrawCircleV(playercenter, playerradius, Color.BLACK);
                Raylib.DrawText(pointcount + pointamount + "/3", 50, 50, 40, Color.WHITE);
                Raylib.DrawText(currentlevel + levelamount, 900, 50, 40, Color.WHITE);
                Raylib.EndDrawing();

            }

            while (Gameover == true)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText(gm, 750, 400, 50, Color.WHITE);
                Raylib.DrawText(res, 700, 600, 40, Color.WHITE);
                Raylib.DrawText(end, 700, 700, 40, Color.WHITE);

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    Gameover = false;
                    scenegame1 = true;

                    player1x = 150;
                    player1y = 150;
                    enemyradius = 50;
                    point1xpos = 300;
                    point1ypos = 885;
                    point2xpos = 1000;
                    point2ypos = 135;
                    point3xpos = 1600;
                    point3ypos = 450;
                    pointamount = 0;
                    levelamount = 1;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                {
                    return;
                }
                Raylib.EndDrawing();
            }
        }
    }
}
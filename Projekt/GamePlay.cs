using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    Player player = new Player();
    HitPosition hitPositionUp;
    HitPosition hitPositionDown;
    Enemy enemy;

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawText("Game", 700, 50, 50, Color.BLACK);
      enemy = new Enemy(1400, 450, 70, 70);
      hitPositionUp = new HitPosition(300, 450, 40, 40, enemy.CollitionalRectangle);
      hitPositionDown = new HitPosition(300, 250, 40, 40, enemy.CollitionalRectangle);


      Rectangle ground = new Rectangle(-10, 500, 2000, 100);

      // !Rektangel lines funkar ej, så får göra linjerna själv
      Raylib.DrawRectangleLines(-10, 553, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 552, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 551, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 550, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 549, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 548, 2000, 100, Raylib_cs.Color.BLACK);
      Raylib.DrawRectangleLines(-10, 547, 2000, 100, Raylib_cs.Color.BLACK);


      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
      Raylib.DrawFPS(10, 10);
    }
  }
}
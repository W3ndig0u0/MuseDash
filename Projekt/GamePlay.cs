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
      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawText("Game", 700, 50, 50, Color.BLACK);
      enemy = new Enemy(1380, 450, 70, 70);


      hitPositionUp = new HitPosition(300, 450, 40, 40, enemy.CollitionalRectangle);
      hitPositionDown = new HitPosition(300, 250, 40, 40, enemy.CollitionalRectangle);


      Rectangle ground = new Rectangle(-10, 500, 2000, 100);

      // !Rektangel lines funkar ej, så får göra linjerna själv
      for (int i = 0; i < 10; i++)
      {
        Raylib.DrawRectangleLines(-10, 555 - i, 2000, 100, Raylib_cs.Color.BLACK);
      }


      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
      Raylib.DrawFPS(10, 10);
    }
  }
}
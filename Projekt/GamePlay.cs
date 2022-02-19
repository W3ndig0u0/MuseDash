using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    Player player = new Player(170, 400, 90, 140);
    HitPosition hitPositionUp = new HitPosition(300, 250, 40, 40);
    HitPosition hitPositionDown = new HitPosition(300, 450, 40, 40);

    Enemy enemy1 = new Enemy(1300, 450, 70, 70);
    Enemy enemy2 = new Enemy(1500, 250, 70, 70);
    Enemy enemy3 = new Enemy(1300, 250, 70, 70);
    Enemy enemy4 = new Enemy(1200, 250, 70, 70);
    Enemy enemy5 = new Enemy(1700, 450, 70, 70);

    public override void Update()
    {
      hitPositionUp.Update();
      hitPositionDown.Update();
      player.Update();

      enemy1.Update();
      enemy2.Update();
      enemy3.Update();
      enemy4.Update();
      enemy5.Update();
    }

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawText("Game", 700, 50, 50, Color.BLACK);

      Rectangle ground = new Rectangle(-10, 500, 2000, 100);

      // !Rektangel lines funkar ej, så får göra linjerna själv
      for (int i = 0; i < 10; i++)
      {
        Raylib.DrawRectangleLines(-10, 555 - i, 2000, 100, Raylib_cs.Color.BLACK);
      }


      Raylib.DrawText("Score", 20, 20, 50, Color.BLACK);
      Raylib.DrawText("0", 20, 60, 50, Color.BLACK);

      hitPositionDown.DrawObject();
      hitPositionUp.DrawObject();
      player.DrawObject();

      enemy1.DrawObject();
      enemy2.DrawObject();
      enemy3.DrawObject();
      enemy4.DrawObject();
      enemy5.DrawObject();

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
      Raylib.DrawFPS(10, 10);
    }
  }
}
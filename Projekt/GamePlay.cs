using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    Player player = new Player(170, 400, 90, 140);
    HitPosition hitPositionUp = new HitPosition(300, 250);
    HitPosition hitPositionDown = new HitPosition(300, 450);

    SmallEnemy enemy1 = new SmallEnemy(1300, 450);
    SmallEnemy enemy2 = new SmallEnemy(1500, 250);
    SmallEnemy enemy3 = new SmallEnemy(1300, 250);
    SmallEnemy enemy4 = new SmallEnemy(1200, 250);
    SmallEnemy enemy5 = new SmallEnemy(1700, 450);

    LargeEnemy largeEnemy = new LargeEnemy(1800, 400);
    Boss boss = new Boss(2200, 350);

    public override void Update()
    {
      hitPositionUp.Update();
      hitPositionDown.Update();

      hitPositionDown.IsOverlapping(enemy1, player);
      hitPositionUp.IsOverlapping(enemy1, player);

      hitPositionDown.IsOverlapping(boss, player);
      hitPositionUp.IsOverlapping(boss, player);

      hitPositionDown.IsOverlapping(largeEnemy, player);
      hitPositionUp.IsOverlapping(largeEnemy, player);

      player.Update();

      enemy1.Update();
      enemy2.Update();
      enemy3.Update();
      enemy4.Update();
      enemy5.Update();
      largeEnemy.Update();
      boss.Update();
    }

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.WHITE);

      // !Debugging Stats
      Raylib.DrawFPS(10, 10);
      Raylib.DrawText("GetTime: " + Raylib.GetTime().ToString(), 10, 30, 20, Color.GREEN);
      Raylib.DrawText("FrameTime: " + Raylib.GetFrameTime().ToString(), 10, 50, 20, Color.GREEN);


      Rectangle ground = new Rectangle(-10, 500, 2000, 100);


      // !Rektangel lines funkar ej, så får göra linjerna själv... :(
      for (int i = 0; i < 14; i++)
      {
        Raylib.DrawRectangleLines(-10, 555 - i, 2000, 100, Raylib_cs.Color.BLACK);
      }

      hitPositionDown.DrawObject();
      hitPositionUp.DrawObject();

      player.DrawObject();

      enemy1.DrawObject();
      enemy2.DrawObject();
      enemy3.DrawObject();
      enemy4.DrawObject();
      enemy5.DrawObject();

      largeEnemy.DrawObject();
      boss.DrawObject();

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
    }
  }
}
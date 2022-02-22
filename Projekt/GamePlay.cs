using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    List<Enemy> enemyList = new List<Enemy>();

    Player player = new Player(170, 400, 90, 140);
    HitPosition hitPositionUp = new HitPosition(300, 250);
    HitPosition hitPositionDown = new HitPosition(300, 450);

    SmallEnemy enemy1 = new SmallEnemy(800, 450);
    SmallEnemy enemy2 = new SmallEnemy(1500, 250);
    SmallEnemy enemy3 = new SmallEnemy(1300, 250);
    SmallEnemy enemy4 = new SmallEnemy(1200, 250);
    SmallEnemy enemy5 = new SmallEnemy(1700, 450);

    LargeEnemy largeEnemy = new LargeEnemy(1800, 400);
    LargeEnemy largeEnemy2 = new LargeEnemy(2700, 200);

    MashEnemy mashEnemy = new MashEnemy(3000, 300);
    GeiminiEnemy geiminiEnemy = new GeiminiEnemy(2500, 450, 250);
    GearObstacle gearObstacle = new GearObstacle(500, 480);

    Boss boss = new Boss(2200, 350);


    bool isDone = false;

    public override void Update()
    {


      // !Lägger till alla fiender
      // !Koden körs bara en gång
      if (isDone == false)
      {
        // enemyList.Add(enemy1);
        // enemyList.Add(enemy2);
        // enemyList.Add(enemy3);
        // enemyList.Add(enemy4);
        // enemyList.Add(enemy5);
        // enemyList.Add(largeEnemy);
        // enemyList.Add(largeEnemy2);
        // enemyList.Add(mashEnemy);
        // enemyList.Add(geiminiEnemy);
        // enemyList.Add(gearObstacle);
        enemyList.Add(boss);
        isDone = true;
      }

      // !Går genom alla Fiender
      for (int i = 0; i < enemyList.Count; i++)
      {
        enemyList[i].Update();
        hitPositionDown.IsOverlapping(enemyList[i], player);
        hitPositionUp.IsOverlapping(enemyList[i], player);
      }


      hitPositionUp.Update();
      hitPositionDown.Update();
      player.Update();

    }

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.WHITE);

      // !Debugging Stats
      Raylib.DrawFPS(10, 10);
      Raylib.DrawText("GetTime: " + Raylib.GetTime().ToString(), 10, 30, 20, Color.GREEN);
      Raylib.DrawText("FrameTime: " + Raylib.GetFrameTime().ToString(), 10, 50, 20, Color.GREEN);


      Rectangle ground = new Rectangle(-10, 500, 2000, 100);

      hitPositionDown.DrawObject();
      hitPositionUp.DrawObject();
      player.DrawObject();

      // !Rektangel lines funkar ej, så får göra linjerna själv... :(
      for (int i = 0; i < 14; i++)
      {
        Raylib.DrawRectangleLines(-10, 555 - i, 2000, 100, Raylib_cs.Color.BLACK);
      }

      // !Går genom alla Fiender
      for (int i = 0; i < enemyList.Count; i++)
      {
        enemyList[i].DrawObject();
      }

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
    }
  }
}
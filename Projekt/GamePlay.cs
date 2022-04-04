using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    public static GameController gamePlay = new GameController();

    Player player = new Player(170, 400, 90, 140);
    SmallEnemy enemy1 = new SmallEnemy(1000, 250);
    SmallEnemy enemy2 = new SmallEnemy(800, 430);
    SmallEnemy enemy3 = new SmallEnemy(1300, 430);
    SmallEnemy enemy4 = new SmallEnemy(1100, 250);
    SmallEnemy enemy5 = new SmallEnemy(1700, 430);

    HitPosition hitPositionDown = new HitPosition(400, 250);
    HitPosition hitPositionUp = new HitPosition(400, 450);

    LargeEnemy largeEnemy = new LargeEnemy(2400, 400);
    LargeEnemy largeEnemy2 = new LargeEnemy(2000, 200);

    MashEnemy mashEnemy = new MashEnemy(2900, 300);
    GeiminiEnemy geiminiEnemy = new GeiminiEnemy(2700, 430, 250);
    GearObstacle gearObstacle = new GearObstacle(500, 480);

    HammerEnemy HammerEnemy1 = new HammerEnemy(3100, -100);
    HammerEnemy HammerEnemy2 = new HammerEnemy(5000, -100);
    HammerEnemy HammerEnemy3 = new HammerEnemy(5800, -100);

    HammerEnemy HammerEnemy4 = new HammerEnemy(5700, -300);
    HammerEnemy HammerEnemy5 = new HammerEnemy(5100, -300);
    HammerEnemy HammerEnemy6 = new HammerEnemy(3000, -300);

    Boss boss = new Boss(3100, 350);


    bool isDone = false;
    bool sceneRemove;

    public override bool Destroyed()
    {
      bool destroyed = false;
      if (sceneRemove == true)
      {
        destroyed = true;
      }
      return destroyed;
    }


    public override void Update()
    {

      if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
      {
        sceneRemove = true;
      }

      // !Lägger till alla fiender
      // !Koden körs bara en gång
      if (isDone == false)
      {
        gamePlay.enemyList.Add(enemy1);
        gamePlay.enemyList.Add(enemy2);
        gamePlay.enemyList.Add(enemy3);
        gamePlay.enemyList.Add(enemy4);
        gamePlay.enemyList.Add(enemy5);
        gamePlay.enemyList.Add(largeEnemy);
        gamePlay.enemyList.Add(largeEnemy2);
        gamePlay.enemyList.Add(mashEnemy);
        gamePlay.enemyList.Add(geiminiEnemy);
        gamePlay.enemyList.Add(boss);

        gamePlay.enemyList.Add(HammerEnemy1);
        gamePlay.enemyList.Add(HammerEnemy2);
        gamePlay.enemyList.Add(HammerEnemy3);
        gamePlay.enemyList.Add(HammerEnemy4);
        gamePlay.enemyList.Add(HammerEnemy5);
        gamePlay.enemyList.Add(HammerEnemy6);


        // enemyList.Add(gearObstacle);
        isDone = true;
      }

      // !Går genom alla Fiender
      for (int i = 0; i < gamePlay.enemyList.Count; i++)
      {
        gamePlay.enemyList[i].Update();
        hitPositionDown.IsOverlapping(gamePlay.enemyList[i], player);
        hitPositionUp.IsOverlapping(gamePlay.enemyList[i], player);

        // !Kör metoden IsOverlapping om man trycker på knapparna 
        // if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
        // {
        //   hitPositionUp.IsOverlapping(gamePlay.enemyList[i], player);
        // }

        // if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE))
        // {
        //   hitPositionDown.IsOverlapping(gamePlay.enemyList[i], player);
        // }
      }

      player.Update();

      gamePlay.FeverMode(player);
      gamePlay.GameOver(player);

      hitPositionUp.Update();
      hitPositionDown.Update();
      // boss.ThrowAttack(430);

    }

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(gamePlay.White);

      // !Debugging Stats
      Raylib.DrawFPS(10, 10);
      Raylib.DrawText("GetTime: " + Raylib.GetTime().ToString(), 10, 30, 20, Color.GREEN);
      Raylib.DrawText("FrameTime: " + Raylib.GetFrameTime().ToString(), 10, 50, 20, Color.GREEN);


      hitPositionDown.DrawObject();
      hitPositionUp.DrawObject();
      player.DrawObject();

      // !Rektangel lines funkar ej, så får göra linjerna själv... :(
      for (int i = 0; i < 14; i++)
      {
        Raylib.DrawRectangleLines(-10, 555 - i, 2000, 100, gamePlay.Black);
      }

      // !Går genom alla Fiender
      for (int i = 0; i < gamePlay.enemyList.Count; i++)
      {
        gamePlay.enemyList[i].DrawObject();
        // Console.WriteLine(gamePlay.enemyList[i].GetType());

      }

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      MenuButton menuButton = new MenuButton(1450, 5, 150, 75, Color.BLACK, "Menu");
      menuButton.Scene = InitGame.currentScene.GetScene(1);
    }
  }
}
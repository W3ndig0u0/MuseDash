using System.Drawing;
using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    Player player = new Player();
    HitPosition hitPositionUp;
    HitPosition hitPositionDown;
    Rectangle ground;

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Raylib_cs.Color.LIGHTGRAY);
      Raylib.DrawText("Game", 700, 50, 50, Raylib_cs.Color.BLACK);
      hitPositionUp = new HitPosition(300, 450, 40, 40, player);
      hitPositionDown = new HitPosition(300, 250, 40, 40, player);
      ground = new Rectangle(0, 400, 2000, 100, Raylib_cs.Color.WHITE);
      Raylib.DrawRectangleLinesEx(ground, 10, Raylib_cs.Color.BLACK);

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Raylib_cs.Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
      Raylib.DrawFPS(10, 10);
    }
  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawCircle(100, 100, 200, Color.BROWN);
      Raylib.DrawText("Game", 700, 50, 50, Color.BLACK);


      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(700, 200, 250, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu");
      Raylib.DrawFPS(10, 10);
    }
  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class MenuScene : Scene
  {
    GamePlay gamePlay = new GamePlay();

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawCircle(100, 100, 200, Color.BROWN);

      new MenuButton(700, 500, 250, 75, Color.BLACK, gamePlay);
      Raylib.DrawFPS(10, 10);
    }
  }
}
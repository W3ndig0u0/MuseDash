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
      Raylib.DrawText("Menu", 700, 250, 50, Color.WHITE);
      new MenuButton(650, 500, 250, 75, Color.BLACK, gamePlay, "Game");
      Raylib.DrawFPS(10, 10);
    }
  }
}
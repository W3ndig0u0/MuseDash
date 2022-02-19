using System;
using Raylib_cs;

namespace Projekt
{
  public class StartScene : Scene
  {
    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawCircle(200, 100, 100, Color.WHITE);
      new MenuButton(750, 300, 250, 75, Color.WHITE);
      new MenuButton(750, 400, 250, 75, Color.WHITE);
      new MenuButton(750, 500, 250, 75, Color.WHITE);
      Raylib.DrawFPS(10, 10);

    }
  }
}
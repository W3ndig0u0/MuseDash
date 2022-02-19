using System;
using Raylib_cs;

namespace Projekt
{
  public class StartScene : Scene
  {

    MenuScene menuScene = new MenuScene();

    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawCircle(200, 100, 100, Color.WHITE);
      new MenuButton(700, 300, 250, 75, Color.WHITE, menuScene);
      Raylib.DrawFPS(10, 10);

    }
  }
}
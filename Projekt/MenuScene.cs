using System;
using Raylib_cs;

namespace Projekt
{
  public class MenuScene : Scene
  {
    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawCircle(100, 200, 100, Color.BROWN);
    }
  }
}
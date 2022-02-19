using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    public override void WhatToDraw()
    {
      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawCircle(100, 100, 200, Color.BROWN);
    }
  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class GamePlay : Scene
  {
    public override void WhatToDraw(Color c)
    {
      Raylib.ClearBackground(c);
      Raylib.DrawCircle(100, 200, 100, c);
    }
  }
}
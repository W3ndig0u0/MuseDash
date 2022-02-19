using System;
using Raylib_cs;

namespace Projekt
{
  public class MenuScene : Scene
  {
    public override void WhatToDraw(Color c)
    {
      Raylib.ClearBackground(c);
      Raylib.DrawCircle(100, 100, 200, c);
    }
  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class StartScene : Scene
  {
    public override void WhatToDraw(Color c)
    {
      Raylib.ClearBackground(c);
      Raylib.DrawCircle(200, 100, 100, c);
    }
  }
}
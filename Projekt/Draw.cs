using System;
using Raylib_cs;

namespace Projekt
{
  public class Draw
  {

    public void RenderScene(Scene s)
    {
      while (!Raylib.WindowShouldClose())
      {
        s.Update();
        Raylib.BeginDrawing();
        s.WhatToDraw();
        Raylib.EndDrawing();
      }
    }
  }
}
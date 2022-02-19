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
        Raylib.BeginDrawing();
        s.WhatToDraw();

        Raylib.EndDrawing();
      }
    }
  }
}
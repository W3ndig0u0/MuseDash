using System;
using Raylib_cs;

namespace Projekt
{
  public class Help : Scene
  {
    bool sceneRemove;
    public bool SceneRemove
    {
      get { return sceneRemove; }
      set { sceneRemove = value; }
    }

    public override void Update()
    {
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
      {
        // sceneRemove = true;
      }
    }

    public override bool Destroyed()
    {
      bool destroyed = false;
      if (sceneRemove == true)
      {
        destroyed = true;
      }
      return destroyed;
    }

    public override void WhatToDraw()
    {
      // !Debugging Stats
      Raylib.DrawFPS(10, 10);
      Raylib.DrawText("GetTime: " + Raylib.GetTime().ToString(), 10, 30, 20, Color.GREEN);
      Raylib.DrawText("FrameTime: " + Raylib.GetFrameTime().ToString(), 10, 50, 20, Color.GREEN);

      // !Text om spelet för spelaren
      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawText("What is this?", 700, 100, 30, Color.BLACK);
      Raylib.DrawText("This is a Muse Dash clone", 300, 200, 20, Color.BLACK);
      Raylib.DrawText("Maping Forum", 300, 300, 20, Color.BLACK);

      Raylib.DrawText("Controlls: Press 2 to hit the air enemies, and press 3 in order to hit the grounded enemies.", 300, 450, 20, Color.BLACK);
      Raylib.DrawText("Try to hit the enemies when they are in the middle of the Circle in order to achive better scores.", 300, 500, 20, Color.BLACK);
    }

  }
}
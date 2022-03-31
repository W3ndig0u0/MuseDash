using System;
using Raylib_cs;

namespace Projekt
{
  public class Mapping : Scene
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
        sceneRemove = true;
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


      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawText("MAPPING", 700, 250, 50, Color.BLACK);

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      new MenuButton(1450, 5, 150, 75, Color.BLACK, InitGame.currentScene.GetScene(1), "Menu", InitGame.currentScene.GetScene(1));


    }

  }
}
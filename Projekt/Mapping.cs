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

    TextBox MapName = new TextBox("Map Name", 400, 200);
    TextBox ArtistName = new TextBox("Artist Name", 400, 400);
    TextBox Diff = new TextBox("Diff", 400, 600);

    public override void WhatToDraw()
    {
      // !Debugging Stats
      Raylib.DrawFPS(10, 10);
      Raylib.DrawText("GetTime: " + Raylib.GetTime().ToString(), 10, 30, 20, Color.GREEN);
      Raylib.DrawText("FrameTime: " + Raylib.GetFrameTime().ToString(), 10, 50, 20, Color.GREEN);

      MapName.DrawBox();
      ArtistName.DrawBox();
      Diff.DrawBox();

      Raylib.ClearBackground(Color.WHITE);
      Raylib.DrawText("Maping Forum", 700, 100, 50, Color.BLACK);

      // !Gå till bakatill menyn, utan att skapa en ny instans av menyn
      MenuButton menuButton = new MenuButton(1450, 5, 150, 75, Color.BLACK, "Menu", InitGame.currentScene.GetScene(1));

    }

  }
}
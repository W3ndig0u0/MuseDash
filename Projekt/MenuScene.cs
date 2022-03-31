using System;
using Raylib_cs;

namespace Projekt
{


  public class MenuScene : Scene
  {

    public bool menuEnabled = false;

    GamePlay gamePlay = new GamePlay();

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
        menuEnabled = true;
      }
    }

    void EscapeMode()
    {
      Raylib.DrawRectangle(530, 300, 500, 200, Color.BLACK);
      Raylib.DrawText("Do You Really Want To Leave?", 590, 360, 25, Color.WHITE);
      Raylib.DrawRectangle(700, 440, 50, 30, Color.GREEN);
      Raylib.DrawRectangle(800, 440, 50, 30, Color.RED);
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

      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawText("Menu", 700, 250, 50, Color.WHITE);
      new MenuButton(650, 500, 250, 75, Color.BLACK, gamePlay, "Game", this);
      new MenuButton(650, 500, 250, 75, Color.BLACK, gamePlay, "Game", this);

      if (menuEnabled)
      {
        EscapeMode();
      }

    }
  }
}
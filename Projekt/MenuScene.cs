using System;
using Raylib_cs;
using System.Numerics;

namespace Projekt
{


  public class MenuScene : Scene
  {

    public bool menuEnabled = false;

    GamePlay gamePlay = new GamePlay();
    Mapping mapping = new Mapping();

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



      if (exitAreOverlapping)
      {

      }
    }

    void EscapeMode()
    {
      
      Raylib.DrawRectangle(530, 200, 500, 200, Color.BLACK);
      Raylib.DrawText("Do You Really Want To Leave?", 590, 260, 25, Color.WHITE);
      new MenuButton(700, 340, 50, 30, Color.GREEN, gamePlay, "No", this);
      MenuButton exit = new MenuButton(800, 340, 50, 30, Color.RED, gamePlay, "Yes", this);
      
    
      Vector2 mousePos = Raylib.GetMousePosition();
      bool exitAreOverlapping = Raylib.CheckCollisionPointRec(mousePos, exit);

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
      new MenuButton(530, 450, 250, 75, Color.BLACK, gamePlay, "Game", this);
      new MenuButton(830, 450, 250, 75, Color.BLACK, mapping, "Mapping", this);

      if (menuEnabled)
      {
        EscapeMode();
      }

    }
  }
}
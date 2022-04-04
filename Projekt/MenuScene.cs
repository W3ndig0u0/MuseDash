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

    }

    void EscapeMode()
    {
      // !Detta aktiveras när esc trycks
      Raylib.DrawRectangle(530, 200, 500, 200, Color.BLACK);
      Raylib.DrawText("Do You Really Want To Leave?", 590, 260, 25, Color.WHITE);
      MenuButton yes = new MenuButton(700, 340, 50, 30, Color.GREEN, "No");
      MenuButton exit = new MenuButton(800, 340, 50, 30, Color.RED, "Yes");

      Vector2 mousePos = Raylib.GetMousePosition();
      bool exitAreOverlapping = Raylib.CheckCollisionPointRec(mousePos, exit.ButtonRectangle);
      bool yesAreOverlapping = Raylib.CheckCollisionPointRec(mousePos, yes.ButtonRectangle);

      // !Lämna spelet
      if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) && exitAreOverlapping)
      {
        sceneRemove = true;
      }

      // !Lämna exit mode
      if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) && yesAreOverlapping)
      {
        menuEnabled = false;
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

      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawText("Menu", 700, 250, 50, Color.WHITE);
      MenuButton GameButton = new MenuButton(530, 450, 250, 75, Color.BLACK, "Game");
      MenuButton MapButton = new MenuButton(830, 450, 250, 75, Color.BLACK, "Mapping");
      // ? gör så att man inte behöver lägga in scenerna manuelt utan att förstöra för knappar som inte har scener
      GameButton.Scene = gamePlay;
      MapButton.Scene = mapping;


      if (menuEnabled)
      {
        EscapeMode();
      }

    }
  }
}
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
    Help help = new Help();

    bool sceneRemove;
    public bool SceneRemove
    {
      get { return sceneRemove; }
      set { sceneRemove = value; }
    }


    public override void Update()
    {
      // !Om EscapeMode är på och man trycker på esc knappen aktiveras Escape men annars stängs escape av (om den redan är på)
      // if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) && !menuEnabled)
      // {
      //   menuEnabled = true;
      // }
      // else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) && menuEnabled)
      // {
      //   menuEnabled = false;
      // }
    }

    void EscapeMode()
    {
      // !Detta aktiveras när esc trycks
      Raylib.DrawRectangle(530, 200, 500, 200, Color.BLACK);
      Raylib.DrawText("Do You Really Want To Leave?", 590, 260, 25, Color.WHITE);
      // ?JAG FIxar att knapparna inte gör nåt senare...

      // MenuButton yes = new MenuButton(700, 340, 50, 30, Color.GREEN, "No", this);
      // MenuButton exit = new MenuButton(800, 340, 50, 30, Color.RED, "Yes", this);

      Vector2 mousePos = Raylib.GetMousePosition();
      // bool exitAreOverlapping = Raylib.CheckCollisionPointRec(mousePos, exit.ButtonRectangle);
      // bool yesAreOverlapping = Raylib.CheckCollisionPointRec(mousePos, yes.ButtonRectangle);

      // !Lämna spelet
      // if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) && exitAreOverlapping)
      // {
      //   sceneRemove = true;
      // }

      // // !Lämna exit mode
      // if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON) && yesAreOverlapping)
      // {
      //   menuEnabled = false;
      // }
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
      MenuButton GameButton = new MenuButton(530, 350, 250, 75, Color.BLACK, "Game", gamePlay);
      MenuButton MapButton = new MenuButton(830, 350, 250, 75, Color.BLACK, "Mapping", mapping);
      MenuButton HelpButton = new MenuButton(630, 550, 250, 75, Color.BLACK, "Help", help);


      if (menuEnabled)
      {
        EscapeMode();
      }

    }
  }
}
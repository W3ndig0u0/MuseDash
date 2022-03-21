using System;
using Raylib_cs;

namespace Projekt
{


  public class MenuScene : Scene
  {
    GamePlay gamePlay = new GamePlay();
    Loading loadingScene;
    public override void Update()
    {
    }

    public override void WhatToDraw()
    {
      loadingScene = new Loading(gamePlay);

      Raylib.ClearBackground(Color.LIGHTGRAY);
      Raylib.DrawText("Menu", 700, 250, 50, Color.WHITE);
      new MenuButton(650, 500, 250, 75, Color.BLACK, gamePlay, "Game");
    }
  }
}
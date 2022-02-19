using System;
using Raylib_cs;

namespace Projekt
{
  public class StartScene : Scene
  {

    int intro = 0;
    MenuScene menuScene = new MenuScene();

    public override void WhatToDraw()
    {
      Sound startSound = Raylib.LoadSound("Sound/SoundEffect/Start.wav");
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawCircle(200, 100, 100, Color.WHITE);
      Raylib.DrawFPS(10, 10);

      // Image wallpapperTetris = Raylib.LoadImage(@"Background2.png");
      // Raylib.ImageResize(ref wallpapperTetris, 1400, 700);
      // Texture2D wallpapperTetrisTexture = Raylib.LoadTextureFromImage(wallpapperTetris);

      intro += 2;

      // !FAde in eller nåt
      if (intro < 100)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
      }

      else if (intro < 500)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
        // Raylib.PlaySound(startSound);
      }

      else if (intro < 2500)
      {
        InitGame.currentScene.AddScene(menuScene);
        InitGame.draw.RenderScene(menuScene);
      }

    }


  }
}
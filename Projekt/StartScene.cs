using System;
using Raylib_cs;

namespace Projekt
{
  public class StartScene : Scene
  {
    int intro;
    MenuScene menuScene = new MenuScene();


    public override void Update()
    {
    }

    public override void WhatToDraw()
    {
      // Sound startSound = Raylib.LoadSound("Sound/SoundEffect/Start.wav");
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawFPS(10, 10);

      intro++;
      // Image wallpapperTetris = Raylib.LoadImage(@"Background2.png");
      // Raylib.ImageResize(ref wallpapperTetris, 1400, 700);
      // Texture2D wallpapperTetrisTexture = Raylib.LoadTextureFromImage(wallpapperTetris);

      // !FAde in eller nåt
      if (intro < 100)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
      }

      else if (intro < 300)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
        // Raylib.PlaySound(startSound);
      }

      else if (intro < 400)
      {
        InitGame.currentScene.AddScene(menuScene);
        InitGame.draw.RenderScene(menuScene);
      }

    }


  }
}
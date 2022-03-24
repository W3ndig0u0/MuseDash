using System;
using Raylib_cs;

namespace Projekt
{
  public class Loading : Scene
  {
    int intro;
    Scene Scene;
    bool sceneRemove;

    public Loading(Scene scene)
    {
      Scene = scene;
      WhatToDraw();
      Update();
    }

    public override void Update()
    {
      intro++;

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
      // Sound startSound = Raylib.LoadSound("Sound/SoundEffect/Start.wav");
      Raylib.ClearBackground(Color.BLACK);
      Raylib.DrawFPS(10, 10);

      // Image wallpapperTetris = Raylib.LoadImage(@"Background2.png");
      // Raylib.ImageResize(ref wallpapperTetris, 1400, 700);
      // Texture2D wallpapperTetrisTexture = Raylib.LoadTextureFromImage(wallpapperTetris);

      // !FAde in eller nåt
      if (intro < 100)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
      }

      else if (intro < 200)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
        // Raylib.PlaySound(startSound);
      }

      else if (intro < 400)
      {
        Raylib.WindowShouldClose();
        sceneRemove = true;
        InitGame.currentScene.AddScene(Scene);
        InitGame.currentScene.PlayScene();

      }

    }


  }
}
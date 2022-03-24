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
      Destroyed();
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

      Image wallpapperImg = Raylib.LoadImage("Texture/EarphonesIntro.png");
      Raylib.ImageResize(ref wallpapperImg, 1400, 700);
      Texture2D wallpapperTexture = Raylib.LoadTextureFromImage(wallpapperImg);

      // !FAde in eller nåt
      if (intro < 100)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
        Raylib.DrawTexture(wallpapperTexture, 0, 0, Color.WHITE);
      }

      else if (intro < 200)
      {
        Raylib.DrawRectangle(0, 0, 1600, 800, Color.BLUE);
        // Raylib.PlaySound(startSound);

        Raylib.DrawTexture(wallpapperTexture, 0, 0, Color.WHITE);
      }

      else if (intro < 800)
      {
        sceneRemove = true;
        InitGame.currentScene.AddScene(Scene);
        InitGame.currentScene.PlayScene();

      }

    }


  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class Loading : Scene
  {
    int intro;
    Scene Scene;
    bool sceneRemove;
    bool TexturLoaded = false;


    Texture2D wallpapperTexture;
    Image wallpapperImg;

    string imgFileName;
    public string ImgFileName
    {
      get { return imgFileName; }
      set { imgFileName = value; }
    }

    public Loading(Scene scene)
    {
      Scene = scene;
    }

    public override void Update()
    {
      intro++;
      Destroyed();
    }

    // !Tar bort Scenen när den nästa dyker fram
    public override bool Destroyed()
    {
      bool destroyed = false;
      if (sceneRemove)
      {
        destroyed = true;
      }
      return destroyed;
    }

    // !Vad som ritas
    public override void WhatToDraw()
    {

      if (!TexturLoaded)
      {
        // Sound startSound = Raylib.LoadSound("Sound/SoundEffect/Start.wav");
        TextureLoad();
        TexturLoaded = true;
        Console.WriteLine(TexturLoaded);
      }

      FadeInOut();

      Raylib.DrawFPS(10, 10);

    }


    // !Laddar Texturen en gång
    void TextureLoad()
    {
      wallpapperImg = Raylib.LoadImage(imgFileName);
      Raylib.ImageResize(ref wallpapperImg, 1600, 800);
      wallpapperTexture = Raylib.LoadTextureFromImage(wallpapperImg);
    }

    void FadeInOut()
    {
      // !FAde in eller nåt
      if (intro < 100)
      {
        Raylib.DrawTexture(wallpapperTexture, 0, 0, Color.WHITE);
      }

      else if (intro < 200)
      {
        Raylib.DrawTexture(wallpapperTexture, 0, 0, Color.WHITE);
      }

      else if (intro < 600)
      {
        sceneRemove = true;
        InitGame.currentScene.AddScene(Scene);
        InitGame.currentScene.PlayScene();
      }

    }

  }
}
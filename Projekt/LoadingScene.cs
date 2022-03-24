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

    Color fade = new Color(0, 0, 0, 255);
    public Color Fade
    {
      get { return fade; }
      set { fade = value; }
    }

    public Loading(Scene scene)
    {
      Scene = scene;
    }

    public override void Update()
    {
      intro++;
      Destroyed();
      FadeInOut();
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
      }

      // FadeInOut();

      Raylib.DrawTexture(wallpapperTexture, 0, 0, fade);

      // Console.WriteLine(intro);

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
      // !Fade in och out animationer

      if (intro <= 50)
      {
        fade.r += 20;
        fade.g += 20;
        fade.b += 20;
        Console.WriteLine(fade.r);
      }

      // else if (intro <= 150 && intro >= 299)
      // {
      //   fade.r -= 20;
      //   fade.g -= 20;
      //   fade.b -= 20;
      //   Console.WriteLine("aaaa");
      //   Raylib.DrawTexture(wallpapperTexture, 0, 0, Fade);
      // }

      if (intro == 300)
      {
        sceneRemove = true;
        InitGame.currentScene.AddScene(Scene);
        InitGame.currentScene.PlayScene();
      }

    }

  }
}
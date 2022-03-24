using System;
using Raylib_cs;

namespace Projekt
{
  public class Loading : Scene
  {
    int intro;
    bool sceneRemove;
    bool TexturLoaded = false;
    bool destroyed = false;

    Texture2D wallpapperTexture;
    Image wallpapperImg;

    string imgFileName;
    public string ImgFileName
    {
      get { return imgFileName; }
      set { imgFileName = value; }
    }

    Color fade;
    public Color Fade
    {
      get { return fade; }
      set { fade = value; }
    }

    Scene nextScene;
    public Scene NextScene
    {
      get { return nextScene; }
      set { nextScene = value; }
    }

    // !Vad Nästa Scene kommer att vara
    public Loading()
    {
      fade = new Color(255, 255, 255, 255);
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

      Raylib.DrawTexture(wallpapperTexture, 0, 0, fade);

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
      if (intro >= 150 && fade.r != 0)
      {
        fade.r -= 3;
        fade.g -= 3;
        fade.b -= 3;
      }

      if (intro == 250)
      {
        sceneRemove = true;
        InitGame.currentScene.AddScene(NextScene);
        InitGame.currentScene.PlayScene();
      }

    }

  }
}
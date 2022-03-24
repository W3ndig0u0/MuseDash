using System.Drawing;
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace Projekt
{
  public class CurrentScene
  {
    List<Scene> scenes = new List<Scene>();
    MenuScene menuScene = new MenuScene();
    Loading loadingScene;


    //! -1 är för att den inte ska köra indexen 1, som inte finns just nu
    int currentScene = -1;

    public CurrentScene()
    {
      // ?FIxa Loading
      loadingScene = new Loading(menuScene);
      // !Berättar vilken bild loading ska ha
      loadingScene.ImgFileName = "Texture/EarphonesIntro.png";
      AddScene(loadingScene);
    }

    //!VIlken Scene som ska rendras, den säger till Draw vad som ska rendras
    public void PlayScene()
    {
      InitGame.draw.RenderScene(scenes[currentScene]);
    }

    public Scene GetScene(int n)
    {
      foreach (var scene in scenes)
      {
        //Console.WriteLine(scene);
      }
      return scenes[currentScene - n];
    }

    //!För att lägga till en scene
    public void AddScene(Scene scene)
    {
      scenes.Add(scene);
      currentScene++;

    }
  }
}
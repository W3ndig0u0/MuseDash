using System.Drawing;
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace Projekt
{
  public class CurrentScene
  {
    List<Scene> scenes = new List<Scene>();
    StartScene startScene = new StartScene();
    Draw draw = new Draw();

    //! -1 är för att den inte ska köra indexen 1, som inte finns just nu
    int currentScene = -1;

    public CurrentScene()
    {
      this.AddScene(startScene);
    }

    //!VIlken Scene som ska rendras
    public void PlayScene()
    {
      draw.RenderScene(scenes[currentScene]);
    }

    //!För att lägga till en scene
    public void AddScene(Scene scene)
    {
      scenes.Add(scene);
      currentScene++;
    }
  }
}
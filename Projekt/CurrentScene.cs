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

    int currentScene;

    //the -1 is due to it otherwice would start at 0 and try to run the scene of index 1, which is non exsistent
    public CurrentScene()
    {
      currentScene = -1;
      this.AddScene(startScene);
    }

    //What scene that should be running
    public void PlayScene()
    {
      // scenes[currentScene].WhatToDraw(Raylib_cs.Color.MAGENTA);
      draw.RenderScene(scenes[currentScene]);
    }

    //if a scene needs to be added
    public void AddScene(Scene scene)
    {
      scenes.Add(scene);
      currentScene++;
    }
  }
}
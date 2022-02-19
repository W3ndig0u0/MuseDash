using System;
using Raylib_cs;

namespace Projekt
{
  public class InitGame
  {
    string windowTitle = "Slutprojekt";
    CurrentScene currentScene = new CurrentScene();

    public InitGame(int WindowWidth, int WindowHeight)
    {
      // !Startar Raylib programmet
      Raylib.InitWindow(WindowWidth, WindowHeight, windowTitle);
      // Raylib.ToggleFullscreen();
      Raylib.SetTargetFPS(120);
      Console.Clear();
      currentScene.PlayScene();
    }

  }
}
using System;
using Raylib_cs;

namespace Projekt
{
  public class InitGame
  {
    string windowTitle = "Slutprojekt";

    public InitGame(int WindowWidth, int WindowHeight)
    {
      // !Startar Raylib programmet
      Raylib.InitWindow(WindowWidth, WindowHeight, windowTitle);
      // Raylib.ToggleFullscreen();
      Raylib.SetTargetFPS(120);
      Console.Clear();
      //   new Draw().RenderScene();
    }

  }
}
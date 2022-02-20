using System;
using Raylib_cs;

namespace Projekt
{
  public class InitGame
  {
    string windowTitle = "Slutprojekt";
    public static CurrentScene currentScene = new CurrentScene();
    public static Draw draw = new Draw();

    public InitGame(int WindowWidth, int WindowHeight)
    {
      // !Startar Raylib programmet
      Raylib.InitWindow(WindowWidth, WindowHeight, windowTitle);
      // Raylib.ToggleFullscreen();
      Raylib.SetTargetFPS(120);
      Raylib.InitAudioDevice();
      Raylib.SetExitKey(0);
      Console.Clear();
      draw.RenderScene(currentScene.GetScene(0));
    }

  }
}
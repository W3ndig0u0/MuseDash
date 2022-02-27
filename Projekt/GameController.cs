using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Projekt
{
  public class GameController
  {
    //   !Håller kolla på alla Fiender i Listan
    public List<Enemy> enemyList;
    public Color Black = Color.BLACK;
    public Color White = Color.WHITE;
    MenuScene menuScene = new MenuScene();

    public GameController()
    {
      enemyList = new List<Enemy>();
    }

    public void FeverMode(Player player)
    {

      if (player.IsFeverMode)
      {
        // !Ändrar färgerna
        Black = Color.WHITE;
        White = Color.BLACK;
      }
      else if (!player.IsFeverMode)
      {
        Black = Color.BLACK;
        White = Color.WHITE;
      }
    }

    public void GameOver(Player player)
    {
      if (player.Hp <= 0)
      {

        // !"Återanvinner" CurrentScene som InitGame skapade, vill inte att varje knapp ska skapa en ny current Scene
        // ?Skapa en gameover scene
        InitGame.currentScene.AddScene(menuScene);
        InitGame.currentScene.PlayScene();
      }
    }

  }
}
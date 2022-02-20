using System;
using Raylib_cs;

namespace Projekt
{
  public class Enemy : Objekt
  {
    bool dead = false;
    public bool Dead
    {
      get { return dead; }
      set { dead = value; }
    }

    int giveFever;
    public int GiveFever
    {
      get { return giveFever; }
      set { giveFever = value; }
    }


    public Enemy(int xPosition, int yPosition)
    {
      YPosition = yPosition - 15;
      XPosition = xPosition;
      GiveFever = 4;
    }

    public void Bounce()
    {

      for (var i = 0; i < 40; i++)
      {
        // !Gör så att det studsar
        YPosition -= 5;
      }
      Dead = true;
    }

    public override void DrawObject()
    {
    }

    public override void Update()
    {
      // !Om Enemy inte har dött
      if (!dead)
      {
        XPosition -= 5;
      }

      // !Så att jag har mer tid att debugga 
      if (XPosition <= 0)
      {
        XPosition = 1600;
      }
    }

  }
}
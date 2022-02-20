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


    public Enemy(int xPosition, int yPosition, int width, int height, int giveScore)
    {
      YPosition = yPosition - 15;
      XPosition = xPosition;
      Width = width;
      Height = height;
      GiveScore = giveScore;
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
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, Width - 35, Height - 35);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 20, Height - 50, Color.GRAY);
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
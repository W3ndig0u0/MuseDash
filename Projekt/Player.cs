using System;
using Raylib_cs;

namespace Projekt
{
  public class Player : Objekt
  {
    int hp;
    int fever;
    int score;

    public Player(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, Width - 35, Height - 35);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);

      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 35, Height - 100, Color.GRAY);

    }

    public override void Update()
    {

    }
  }
}
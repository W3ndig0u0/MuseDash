using System;
using Raylib_cs;

namespace Projekt
{
  public class Boss : Enemy
  {
    public Boss(int xPosition, int yPosition, int width, int height, int giveScore) : base(xPosition, yPosition, width, height, giveScore)
    {
      GiveFever = 8;
    }

    // ?3 Attack modes
    // ?Kasta enemy
    // ?Spring mot spelaren men spelaren slår en gång
    // ?Spring mot spelaren men spelaren kan slå många ggr

    public override void DrawObject()
    {

      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition, Width - 55, Height);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 80, Height - 160, Color.GRAY);
    }

  }
}
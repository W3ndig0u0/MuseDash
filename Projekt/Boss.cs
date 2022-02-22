using System;
using Raylib_cs;

namespace Projekt
{
  public class Boss : Enemy
  {

    int WidthBoos;
    int HeightBoss;

    public Boss(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      GiveFever = 4;
      WidthBoos = 160;
      HeightBoss = 200;
      GiveScore = 400;
    }

    // ?3 Attack modes
    // ?Kasta enemy
    // ?Spring mot spelaren men spelaren slår en gång
    // ?Mash attack

    public override void DrawObject()
    {

      Sprite = new Rectangle(XPosition, YPosition, WidthBoos, HeightBoss);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 60, WidthBoos - 100, HeightBoss - 130);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 80, 600, WidthBoos - 80, HeightBoss - 180, Color.GRAY);
    }

  }
}
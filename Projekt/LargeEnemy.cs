using System;
using Raylib_cs;

namespace Projekt
{
  public class LargeEnemy : Enemy
  {
    int WidthLargeEnemy;
    int HeightLargeEnemy;

    public LargeEnemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthLargeEnemy = 90;
      HeightLargeEnemy = 120;
      GiveFever = 4;
      GiveScore = 400;
    }

    public override void DrawObject()
    {

      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= -100 && YPosition >= -200 && XPosition <= 1800 && YPosition <= 1000)
      {
        Sprite = new Rectangle(XPosition, YPosition, WidthLargeEnemy, HeightLargeEnemy);
        CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, WidthLargeEnemy - 55, HeightLargeEnemy - 55);

        Raylib.DrawRectangleRec(Sprite, Color.BLACK);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 40, 600, WidthLargeEnemy - 50, HeightLargeEnemy - 100, Color.GRAY);
      }
    }

  }
}
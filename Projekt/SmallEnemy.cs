using System;
using Raylib_cs;

namespace Projekt
{
  public class SmallEnemy : Enemy
  {
    int WidthSmallEnemy;
    int HeightSmallEnemy;

    public SmallEnemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthSmallEnemy = 70;
      HeightSmallEnemy = 70;
      GiveFever = 2;
      GiveScore = 200;
    }

    public override void DrawObject()
    {
      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= 0 && YPosition >= 0 && XPosition <= 1600 && YPosition <= 900)
      {

        Sprite = new Rectangle(XPosition, YPosition, WidthSmallEnemy, HeightSmallEnemy);
        CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, WidthSmallEnemy - 35, HeightSmallEnemy - 35);

        Raylib.DrawRectangleRec(Sprite, Color.BLACK);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 40, 600, WidthSmallEnemy - 20, HeightSmallEnemy - 50, Color.GRAY);
      }
    }

  }
}
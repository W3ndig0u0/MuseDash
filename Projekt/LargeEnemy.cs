using System;
using Raylib_cs;

namespace Projekt
{
  public class LargeEnemy : Enemy
  {
    int WidthLargeEnemy;
    int HeightLargeEnemy;
    int YPositionLargeEnemy;

    public LargeEnemy(int xPosition, int yPosition, int width, int height, int giveScore) : base(xPosition, yPosition, width, height, giveScore)
    {
      WidthLargeEnemy = width;
      HeightLargeEnemy = height;
      GiveFever = 6;
      YPositionLargeEnemy = yPosition - 10;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, Width - 55, Height - 55);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 40, Height - 100, Color.GRAY);
    }

  }
}
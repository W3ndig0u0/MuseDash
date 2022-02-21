using System;
using Raylib_cs;

namespace Projekt
{
  public class GearObstacle : Enemy
  {
    int WidthGearObstacle;
    int HeightGearObstacle;
    int YPositionGearObstacle;

    public GearObstacle(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthGearObstacle = 90;
      HeightGearObstacle = 120;
      GiveFever = 3;
      GiveScore = 400;
      YPositionGearObstacle = 500;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPositionGearObstacle, WidthGearObstacle, HeightGearObstacle);
      CollitionalRectangle = new Rectangle(XPosition, YPositionGearObstacle - 20, WidthGearObstacle - 55, HeightGearObstacle);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !Ingen skugga för den här fienden
      // Raylib.DrawEllipse(XPosition + 40, 600, WidthGearObstacle - 50, HeightGearObstacle - 100, Color.GRAY);
    }

  }
}
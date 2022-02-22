using System;
using Raylib_cs;


namespace Projekt
{
  public class MashEnemy : Enemy
  {
    int WidthMashEnemy;
    int HeightMashEnemy;
    int YPositionMashEnemy;

    public MashEnemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthMashEnemy = 100;
      HeightMashEnemy = 140;
      GiveFever = 0;
      GiveScore = 20;
      YPositionMashEnemy = 400;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPositionMashEnemy, WidthMashEnemy, HeightMashEnemy);
      CollitionalRectangle = new Rectangle(XPosition, YPositionMashEnemy + 20, WidthMashEnemy - 55, HeightMashEnemy - 55);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, WidthMashEnemy - 50, HeightMashEnemy - 100, Color.GRAY);
    }



    // ?Om den nuddar collision, har man en timer att slå sönder


  }
}
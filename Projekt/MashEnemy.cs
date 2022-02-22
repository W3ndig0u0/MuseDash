using System;
using Raylib_cs;


namespace Projekt
{
  public class MashEnemy : Enemy
  {
    int WidthMashEnemy;
    int HeightMashEnemy;

    public MashEnemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthMashEnemy = 100;
      HeightMashEnemy = 140;
      GiveFever = 0;
      GiveScore = 20;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, WidthMashEnemy, HeightMashEnemy);
      CollitionalRectangle = new Rectangle(XPosition, YPosition - 100, WidthMashEnemy - 55, HeightMashEnemy - 55);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, WidthMashEnemy - 50, HeightMashEnemy - 100, Color.GRAY);
    }



    // ?Om den nuddar collision, har man en timer att slå sönder


  }
}
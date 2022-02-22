using System;
using Raylib_cs;

namespace Projekt
{
  public class GeiminiEnemy : Enemy
  {
    int WidthGeiminiEnemy;
    int HeightGeiminiEnemy;
    int YPositionGeiminiEnemy1;

    // !Detta är för den övre delen av fienden
    int YPositionGeiminiEnemy2;
    Rectangle sprite2;

    // !Delen som är mellan de övre och nedre delen
    Rectangle spriteMiddle;

    public GeiminiEnemy(int xPosition, int yPosition, int yPosition2) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      WidthGeiminiEnemy = 70;
      HeightGeiminiEnemy = 70;
      GiveFever = 4;
      GiveScore = 400;
      YPositionGeiminiEnemy2 = yPosition2;
      YPositionGeiminiEnemy1 = yPosition;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPositionGeiminiEnemy1, WidthGeiminiEnemy, HeightGeiminiEnemy);
      sprite2 = new Rectangle(XPosition, YPositionGeiminiEnemy2, WidthGeiminiEnemy, HeightGeiminiEnemy);
      // !200 är avståndet mellan övre och nedre delen
      spriteMiddle = new Rectangle(XPosition + 20, YPositionGeiminiEnemy2 + 70, 30, 180);


      CollitionalRectangle = new Rectangle(XPosition, YPositionGeiminiEnemy2, WidthGeiminiEnemy - 35, HeightGeiminiEnemy - 35);

      Raylib.DrawRectangleRec(spriteMiddle, Color.BLACK);
      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(sprite2, Color.BLACK);

      // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      // !Detta är skuggan
      Raylib.DrawEllipse(XPosition + 40, 600, WidthGeiminiEnemy - 50, HeightGeiminiEnemy - 100, Color.GRAY);
    }


    public override void Update()
    {
      GeimiDead();
    }

    void GeimiDead()
    {

      XPosition -= 5;
      if (IsHurt)
      {
        YPositionGeiminiEnemy1 -= 10;
        YPositionGeiminiEnemy2 -= 10;
        // spriteMiddle.y = 10000;
      }
    }

  }
}
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

      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= 0 && YPosition >= 0 && XPosition <= 1600 && YPosition <= 1000)
      {
        Sprite = new Rectangle(XPosition, YPosition, WidthMashEnemy, HeightMashEnemy);
        CollitionalRectangle = new Rectangle(XPosition, YPosition - 100, WidthMashEnemy - 55, HeightMashEnemy - 55);

        Raylib.DrawRectangleRec(Sprite, GamePlay.gamePlay.Black);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 40, 600, WidthMashEnemy - 50, HeightMashEnemy - 120, Color.GRAY);
      }
    }

    public override void Update()
    {
      MashDead();
    }

    void MashDead()
    {

      if (IsHurt)
      {
        XPosition += 5;
        YPosition -= 10;
      }
      else
      {
        XPosition -= 5;
      }
    }



    // ?Om den nuddar collision, har man en timer att slå sönder


  }
}
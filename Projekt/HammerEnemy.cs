using System;
using Raylib_cs;

namespace Projekt
{
  public class HammerEnemy : Enemy
  {
    int WidthHammerEnemy;
    int HeightHammerEnemy;

    int xPosLine;
    int yPosLine;

    public HammerEnemy(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      WidthHammerEnemy = 90;
      HeightHammerEnemy = 90;
      GiveFever = 8;
      GiveScore = 400;


      xPosLine = 1200;
      yPosLine = yPosition;
    }

    public override void DrawObject()
    {
      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= -100 && YPosition >= -100 && XPosition <= 1800 && YPosition <= 1000)
      {

        Sprite = new Rectangle(XPosition, YPosition, WidthHammerEnemy, HeightHammerEnemy);
        CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, WidthHammerEnemy - 35, HeightHammerEnemy - 35);
        Raylib.DrawRectangleRec(Sprite, GamePlay.gamePlay.Black);

        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !Thicknes vill ej funka, få göra det själv...
        for (int i = 0; i < 5; i++)
        {
          Raylib.DrawLine(xPosLine + i, yPosLine + i, XPosition + i + 40, YPosition + i + 40, GamePlay.gamePlay.Black);
        }

        // !600 är vart Marken beffiner sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 40, 600, WidthHammerEnemy - 20, HeightHammerEnemy - 50, Color.GRAY);
      }
    }

    public override void Update()
    {
      if (!Dead)
      {
        EntryAnimation();
      }

      else if (Dead)
      {
        DeadAnimation();
      }
    }

    void DeadAnimation()
    {
      // ? fixa så att den inte måste ha 7 i speed
      XPosition += 5 + 2;
      xPosLine += 4;
      // !Kurvan när fienden träffas
      // ?Jag fixar detta senare
      if (XPosition <= 500)
      {
        YPosition += 1;
        Console.WriteLine("1");
      }
      else if (XPosition < 501 && XPosition >= 550)
      {
        Console.WriteLine("2");
        YPosition -= 1;
      }
      else if (XPosition < 551 && XPosition >= 650)
      {
        Console.WriteLine("3");
        YPosition -= 3;
      }
      else if (XPosition < 651 && XPosition >= 700)
      {
        Console.WriteLine("4");
        YPosition -= 6;
      }
      else if (XPosition >= 701)
      {
        Console.WriteLine("5");
        YPosition -= 8;
      }
    }

    void EntryAnimation()
    {
      // ? fixa så att den inte måste ha 7 i speed
      XPosition -= 5 + 2;
      xPosLine -= 4;

      // !Kurvan när fienden kommer
      // ?Jag fixar detta senare
      if (XPosition <= 1200 && XPosition > 1001)
      {
        YPosition += 8;
      }
      else if (XPosition <= 1000 && XPosition > 801)
      {
        YPosition += 6;
      }
      else if (XPosition <= 800 && XPosition > 601)
      {
        YPosition += 4;
      }
      else if (XPosition <= 600 && XPosition > 401)
      {
        YPosition += 1;
      }
      else if (XPosition <= 400)
      {
        YPosition -= 1;
      }
    }

  }
}
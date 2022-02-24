using System;
using Raylib_cs;

namespace Projekt
{
  public class HammerEnemy : Enemy
  {
    int WidthHammerEnemy;
    int HeightHammerEnemy;
    int GoalYPosition;
    int GoalXPosition;
    int timer;

    public HammerEnemy(int xPosition, int yPosition, int goalXPosition, int goalYPosition) : base(xPosition, yPosition)
    {
      GoalYPosition = goalYPosition;
      GoalXPosition = goalXPosition;

      WidthHammerEnemy = 90;
      HeightHammerEnemy = 90;
      GiveFever = 2;
      GiveScore = 200;
    }

    public override void DrawObject()
    {
      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= -100 && YPosition >= -100 && XPosition <= 1800 && YPosition <= 1000)
      {

        Sprite = new Rectangle(XPosition, YPosition, WidthHammerEnemy, HeightHammerEnemy);
        CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, WidthHammerEnemy - 35, HeightHammerEnemy - 35);
        Raylib.DrawRectangleRec(Sprite, Color.BLACK);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 40, 600, WidthHammerEnemy - 20, HeightHammerEnemy - 50, Color.GRAY);
      }
    }

    public override void Update()
    {
      // Console.WriteLine(TimerDead);
      if (YPosition != GoalYPosition && XPosition != GoalXPosition && IsHurt == false)
      {
        timer++;

        // !Kurvan när fienden dör
        if (timer >= 0 && timer < 15)
        {
          YPosition += 10;
        }
        else if (timer > 15 && timer < 25)
        {
          YPosition += 5;
        }
        else if (timer > 25 && timer < 35)
        {
          YPosition += 3;
        }
        else if (timer > 35 && timer < 40)
        {
          YPosition += 1;
        }
        else if (timer > 40 && timer < 50)
        {
          YPosition -= 1;
        }
        else if (timer > 50 && timer < 60)
        {
          YPosition -= 5;
        }
        else if (timer > 60)
        {
          YPosition -= 10;
        }

      }
    }
  }
}
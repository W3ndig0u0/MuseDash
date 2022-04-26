using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class Boss : Enemy
  {

    int WidthBoos;
    int HeightBoss;
    int timer;
    int attacked;
    bool isSprintAttack = false;
    int xBase = 1300;

    public Boss(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      GiveFever = 4;
      WidthBoos = 160;
      HeightBoss = 200;
      GiveScore = 400;
    }

    // ?2 Attack modes
    // ?Kasta små fiender
    // ?Spring mot spelaren snabbt men spelaren slår en gång

    // !Bossen springer mot spelaren och sen ska spelaren slå bort bossen med ett slag
    public void SprintAttack()
    {
      isSprintAttack = true;

      if (IsHurt)
      {
        // !Om bossen blir skadad, kommer den antigen gå tillbaka till kastning attacken, eller springa iväg
        if (XPosition <= xBase)
        {
          XPosition += 5;
          isSprintAttack = false;
        }
        if (XPosition == xBase)
        {
          // !Resta timern när bossen är tillbaka
          timer = 0;
          IsHurt = false;
          attacked++;
        }
      }
      else
      {
        XPosition -= 20;
      }

    }

    // !Bossen kastar små fiender på spelaren, deafualt attacken
    public void ThrowAttack(int yPos)
    {
      // if (XPosition == xBase)
      // {
      SmallEnemy enemy = new SmallEnemy(XPosition, yPos);

      GamePlay.gamePlay.enemyList.Add(enemy);
      // Console.WriteLine(enemy.XPosition);
      // !Lägger in Fienden till Listan som finns i GamePLay
      // }
    }

    public override void Update()
    {
      // !Går fram till bossens "ställe" om den inte är skadad och inte där än
      if (XPosition >= xBase && !isSprintAttack)
      {
        XPosition -= 5;
      }
      else
      {
        timer++;
      }

      // Console.WriteLine(timer);
      // !GÖe en attack när tiden har gått
      if (timer == 200)
      {
        ThrowAttack(250);
        ThrowAttack(430);
      }

      if (timer >= 500)
      {
        SprintAttack();
      }

    }

    public override void DrawObject()
    {

      // !Ritar inte sakerna om de inte är med i skärmen
      if (XPosition >= 0 && YPosition >= 0 && XPosition <= 1600 && YPosition <= 1000)
      {
        Sprite = new Rectangle(XPosition, YPosition, WidthBoos, HeightBoss);
        CollitionalRectangle = new Rectangle(XPosition, YPosition + 60, WidthBoos - 100, HeightBoss - 130);

        Raylib.DrawRectangleRec(Sprite, GamePlay.gamePlay.Black);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 80, 600, WidthBoos - 80, HeightBoss - 180, Color.GRAY);
      }
    }

  }
}
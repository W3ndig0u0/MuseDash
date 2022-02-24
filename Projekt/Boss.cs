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
    bool isThrowingAttack = false;
    int xBase = 1300;
    List<SmallEnemy> enemies = new List<SmallEnemy>();


    public Boss(int xPosition, int yPosition) : base(xPosition, yPosition)
    {
      // !Detta gör att det blir lättare med level editorn
      GiveFever = 4;
      WidthBoos = 160;
      HeightBoss = 200;
      GiveScore = 400;
    }

    // ?3 Attack modes
    // ?Kasta små fiender
    // ?Spring mot spelaren snabbt men spelaren slår en gång
    // ?Spring mot spelaren segt och sen Mash attack

    // !Bossen går mot spelaren och sen ska spelaren masha
    public void MashAttack()
    {
      // !Sista attacken när den är nästan "död"
      if (attacked == 2)
      {

      }
    }

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
      isThrowingAttack = false;
      SmallEnemy enemy = new SmallEnemy(XPosition, yPos);

      GamePlay.gamePlay.enemyList.Add(enemy);
      // Console.WriteLine(enemy.XPosition);
      // !Lägger in Fienden till Listan som finns i GamePLay
      // isThrowingAttack = true;
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

      // if (timer == 200)
      // {
      ThrowAttack(250);
      ThrowAttack(430);
      // }

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

        Raylib.DrawRectangleRec(Sprite, Color.BLACK);
        // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

        // !600 är vart Marken beffiner  sig
        // !Detta är skuggan
        Raylib.DrawEllipse(XPosition + 80, 600, WidthBoos - 80, HeightBoss - 180, Color.GRAY);
      }
    }

  }
}
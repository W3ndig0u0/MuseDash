using System;
using Raylib_cs;

namespace Projekt
{
  public class Boss : Enemy
  {

    int WidthBoos;
    int HeightBoss;
    int timer;
    bool isAttack = false;

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

    }

    // !Bossen springer mot spelaren och sen ska spelaren slå bort bossen med ett slag
    public void SprintAttack()
    {
      isAttack = true;
      XPosition -= 10;
      Console.WriteLine("s");

      if (IsHurt)
      {
        // !Om bossen blir skadad, kommer den antigen gå tillbaka till kastning attacken, eller springa iväg
        if (XPosition != 1000)
        {
          XPosition += 10;
          timer = 0;
          isAttack = false;
        }
      }
    }

    // !Bossen kastar små fiender på spelaren, deafualt attacken
    public void ThrowAttack()
    {

    }

    public override void Update()
    {
      // !Går fram till bossens "ställe" om den inte är skadad och inte där än
      if (XPosition != 1000 && !isAttack)
      {
        XPosition -= 5;
      }

      timer++;
      if (timer >= 500)
      {
        Console.WriteLine("FIRE");
        SprintAttack();
      }
    }

    public override void DrawObject()
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
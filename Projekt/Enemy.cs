using System;
using Raylib_cs;

namespace Projekt
{
  public class Enemy : Objekt
  {
    bool dead = false;
    public bool Dead
    {
      get { return dead; }
      set { dead = value; }
    }

    int giveFever;
    public int GiveFever
    {
      get { return giveFever; }
      set { giveFever = value; }
    }

    int timer;
    public int Timer
    {
      get { return timer; }
      set { timer = value; }
    }

    int timerDead;
    public int TimerDead
    {
      get { return timerDead; }
      set { timerDead = value; }
    }

    bool mash = false;
    public bool Mash
    {
      get { return mash; }
      set { mash = value; }
    }

    // !För mash
    int mashCombo;

    public Enemy(int xPosition, int yPosition)
    {
      YPosition = yPosition - 15;
      XPosition = xPosition;
    }

    // !Vad som händer när en fiende "dör"
    public void DeadMethod()
    {
      Dead = true;
    }

    // !För fiender som har en mash time
    public void TimerMash(int timerOut)
    {
      //! Timerout kommer bero på hur länge den kan mashas
      if (Timer != timerOut)
      {
        MashMethod();
        Console.WriteLine(timerOut);
      }

      // if (Timer == timerOut)
      // {
      //   Bounce();
      // }
    }

    void MashMethod()
    {
      Mash = true;
      // ?Combo ökar när man tryckers
      mashCombo++;
      Timer++;

      this.XPosition += 5;
      Raylib.DrawText(mashCombo.ToString(), XPosition, YPosition - 50, 50, Color.BLACK);
    }


    public override void DrawObject()
    {
    }

    public override void Update()
    {
      // !Om Enemy inte har dött
      if (!Dead)
      {
        XPosition -= 5;
      }

      // !När Enemy är död
      if (Dead)
      {
        // !Gör så att det studsar
        TimerDead++;
        Dead = true;

        if (TimerDead != 500)
        {
          XPosition -= 5;
          // !Kurvan när fienden dör
          YPosition = ((XPosition - 5) * (1 / 3)) ^ 2;
        }
      }

      // !Så att jag har mer tid att debugga 
      // if (XPosition <= -100)
      // {
      //   XPosition = 2500;
      // }
    }

  }
}
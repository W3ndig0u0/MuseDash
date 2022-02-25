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

    bool isHurt;
    public bool IsHurt
    {
      get { return isHurt; }
      set { isHurt = value; }
    }

    // !För mash
    int mashCombo;
    int fakeGravity;
    public int FakeGravity
    {
      get { return fakeGravity; }
      set { fakeGravity = value; }
    }

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
      if (Timer < timerOut)
      {
        MashMethod();
      }

      else if (Timer == timerOut)
      {
        IsHurt = true;
      }
    }

    void MashMethod()
    {
      Mash = true;

      // ?Combo ökar när man tryckers
      mashCombo++;
      Timer++;

      this.XPosition += 5;
      Raylib.DrawText(mashCombo.ToString(), XPosition, YPosition - 90, 50, GamePlay.gamePlay.Black);
    }


    public override void DrawObject()
    {
    }

    public override void Update()
    {
      Bounce();
    }

    void Bounce()
    {
      // !Om Enemy inte har dött
      if (!Dead)
      {
        // !Boss ska inte springa rakt mot spelaren, utan stannar
        if (this is Boss)
        {
          return;
        }

        XPosition -= 5;

        // !Kurvan när fienden dör
      }

      // !När Enemy är död
      if (Dead)
      {
        TimerDead++;
        // Console.WriteLine(TimerDead);

        XPosition -= 5;

        // !Kurvan när fienden dör
        if (TimerDead >= 0 && TimerDead < 15)
        {
          YPosition -= 10;
        }
        else if (TimerDead > 15 && TimerDead < 25)
        {
          YPosition -= 5;
        }
        else if (TimerDead > 25 && TimerDead < 35)
        {
          YPosition -= 3;
        }
        else if (TimerDead > 35 && TimerDead < 40)
        {
          YPosition -= 1;
        }
        else if (TimerDead > 40 && TimerDead < 50)
        {
          YPosition += 1;
        }
        else if (TimerDead > 50 && TimerDead < 60)
        {
          YPosition += 5;
        }
        else if (TimerDead > 60)
        {
          YPosition += 10;
        }

        // TimerDead++;
        Dead = true;
        // if (TimerDead != 500 && XPosition > -100)
        // {



        // !Så att jag har mer tid att debugga 
        // if (XPosition <= -100)
        // {
        //   XPosition = 2500;
        // }
      }
    }
  }
}
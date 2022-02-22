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
      Raylib.DrawText(mashCombo.ToString(), XPosition, YPosition - 90, 50, Color.BLACK);
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

        // FakeGravity += fakeGravity / 2;
        // !Gör så att det studsar
        // TimerDead++;
        Dead = true;

        // if (TimerDead != 500 && XPosition > -100)
        // {

        // !Kurvan när fienden dör

        XPosition -= 5;
        YPosition -= 10;


        // !Så att jag har mer tid att debugga 
        // if (XPosition <= -100)
        // {
        //   XPosition = 2500;
        // }
      }
    }
  }
}
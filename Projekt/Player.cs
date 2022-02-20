using System;
using Raylib_cs;

namespace Projekt
{
  public class Player : Objekt
  {
    int hp;
    public int Hp
    {
      get { return hp; }
      set { hp = value; }
    }

    int fever;
    public int Fever
    {
      get { return fever; }
      set { fever = value; }
    }

    int score;
    public int Score
    {
      get { return score; }
      set { score = value; }
    }

    int combo;
    public int Combo
    {
      get { return combo; }
      set { combo = value; }
    }

    public Player(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, Width - 35, Height - 35);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);

      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 35, Height - 100, Color.GRAY);

    }

    public override void Update()
    {

    }
  }
}
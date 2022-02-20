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

    //! Texture
    Texture2D hpTexture;
    Texture2D feverTexture;
    Texture2D hpExtraTexture;

    public Player(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      hpTexture = Raylib.LoadTexture("Texture/HpMeter.png");
      feverTexture = Raylib.LoadTexture("Texture/FeverMeter.png");
      hpExtraTexture = Raylib.LoadTexture("Texture/ExtraUI.png");
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition + 35, YPosition, Width - 35, Height);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !Score, hp, etc
      Raylib.DrawText("Score", 10, 80, 50, Color.BLACK);
      Raylib.DrawText(Score.ToString(), 10, 140, 50, Color.BLACK);
      Raylib.DrawText(Combo.ToString(), 700, 50, 50, Color.BLACK);

      Raylib.DrawTexture(hpTexture, 500, 750, Color.WHITE);
      Raylib.DrawTexture(feverTexture, 500, 700, Color.WHITE);
      Raylib.DrawTexture(hpExtraTexture, 500, 700, Color.WHITE);


      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 35, Height - 120, Color.GRAY);

    }

    // !Spelarens rörelse

    // !GÖr så att man läser detta från settings text + kan ändra knapparna
    public override void Update()
    {
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
      {
        Air();
      }
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE))
      {
        Ground();
      }
    }

    // !Vart spelaren hamnar
    void Air()
    {
      YPosition = 200;
    }
    void Ground()
    {
      YPosition = 400;
    }

  }
}
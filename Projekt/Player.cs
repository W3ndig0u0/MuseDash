using System;
using System.Numerics;
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

    //! Texture2D
    Texture2D hpTexture;
    Texture2D feverTexture;
    Texture2D hpExtraTexture;

    Rectangle hpRect;
    Rectangle feverRect;
    Rectangle extraRect;

    Random random;
    int radius;
    public int Radius
    {
      get { return radius; }
      set { radius = value; }
    }

    Color color;
    public Color Color
    {
      get { return color; }
      set { color = value; }
    }


    public Player(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;


      hpRect = new Rectangle(540, 755, 470, 50);
      feverRect = new Rectangle(970, 755, 100, 50);
      extraRect = new Rectangle(447, 745, 100, 55);

      hpTexture = Raylib.LoadTexture("Texture/HpMeter.png");
      feverTexture = Raylib.LoadTexture("Texture/FeverMeter3.png");
      hpExtraTexture = Raylib.LoadTexture("Texture/ExtraUI.png");
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition + 35, YPosition, Width - 35, Height);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 35, Height - 120, Color.GRAY);
      HpFever();
      ScoreCircle();
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
      RandomCircleDraw();
    }

    void RandomCircleDraw()
    {
      Radius = random.Next(10, 50);
      Color = new Color(random.Next(0, 50), random.Next(0, 50), random.Next(0, 50), random.Next(0, 255));
    }

    void ScoreCircle()
    {
      Raylib.DrawCircle(750, 100, Radius, Color);
      Raylib.DrawText(Combo.ToString(), 720, 60, 50, Color.BLACK);
    }

    void HpFever()
    {
      // !Score, hp, etc
      Raylib.DrawText("Score", 10, 80, 50, Color.BLACK);
      Raylib.DrawText(Score.ToString(), 10, 140, 50, Color.BLACK);

      // Raylib.DrawRectangleRec(hpRect, Color.RED);
      // Raylib.DrawRectangleRec(feverRect, Color.BLUE);
      // Raylib.DrawRectangleRec(extraRect, Color.GREEN);

      Raylib.DrawTexture(hpTexture, 540, 755, Color.WHITE);
      Raylib.DrawTexture(feverTexture, 595, 755, Color.WHITE);
      Raylib.DrawTexture(hpExtraTexture, 447, 745, Color.WHITE);


      Raylib.DrawText("Fever", 980, 775, 20, Color.BLACK);
      Raylib.DrawText("250/250", 730, 775, 20, Color.BLACK);

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
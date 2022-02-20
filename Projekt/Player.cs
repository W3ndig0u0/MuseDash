using System;
using System.Collections.Generic;
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

    Random random = new Random();
    int radius;
    public int Radius
    {
      get { return radius; }
      set { radius = value; }
    }

    // !Detta är för combo cirkeln
    Vector2 pos;
    Vector2 pos2;
    float timer;

    Color color;
    public Color Color
    {
      get { return color; }
      set { color = value; }
    }

    List<Vector2> vector2List = new List<Vector2>();


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


      RandomCircleDraw();
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

      // !Timer för när en ny cirkel ska skapas
      timer++;
      if (timer == 120f)
      {
        RandomCircleDraw();
        timer = 0f;
      }
    }

    void RandomCircleDraw()
    {
      // !Gör nya stats för cirklarna hela tiden
      Radius = random.Next(30, 70);
      Color = new Color(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(175, 255));
      pos.X = random.Next(700, 800);
      pos.Y = random.Next(80, 120);

      pos2.X = random.Next(700, 800);
      pos2.Y = random.Next(80, 120);

      vector2List.Add(pos);
      vector2List.Add(pos2);
    }

    void ScoreCircle()
    {

      for (int i = 0; i < vector2List.Count; i++)
      {
        // !SKriver ut flera random cirklor med från listan
        Raylib.DrawCircle((int)Math.Round(vector2List[i].X), (int)Math.Round(vector2List[i].Y), Radius, Color);
        Raylib.DrawCircle((int)Math.Round(vector2List[i].X - 10), (int)Math.Round(vector2List[i].Y - 20), Radius / 2, Color);
        Raylib.DrawCircle((int)Math.Round(vector2List[i].X + 10), (int)Math.Round(vector2List[i].Y + 20), Radius / 2, Color);
      }

      Raylib.DrawText(Combo.ToString(), 700, 60, 50, Color.WHITE);
      Raylib.DrawText("COMBO", 690, 100, 30, Color.WHITE);
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
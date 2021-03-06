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

    int maxHp;
    public int MaxHp
    {
      get { return maxHp; }
      set { maxHp = value; }
    }

    int maxFever;
    public int MaxFever
    {
      get { return maxFever; }
      set { maxFever = value; }
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
    Rectangle hpMaxRect;
    Rectangle feverRect;
    Rectangle feverMaxRect;

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
    float feverTimer;

    Color color;
    public Color Color
    {
      get { return color; }
      set { color = value; }
    }
    HashSet<Vector2> vector2Set = new HashSet<Vector2>();

    bool isFeverMode = false;
    public bool IsFeverMode
    {
      get { return isFeverMode; }
      set { isFeverMode = value; }
    }


    public Player(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      Hp = 300;
      maxHp = hp;
      Fever = 0;
      maxFever = 300;

      IsFeverMode = false;

      hpTexture = Raylib.LoadTexture("Texture/HpMeter.png");
      feverTexture = Raylib.LoadTexture("Texture/FeverMeter3.png");
      hpExtraTexture = Raylib.LoadTexture("Texture/ExtraUI.png");


      // RandomCircleDraw();
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition + 35, YPosition, Width - 35, Height);

      Raylib.DrawRectangleRec(Sprite, GamePlay.gamePlay.Black);
      // Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      hpRect = new Rectangle(555, 755, Hp, 40);
      feverRect = new Rectangle(555, 705, Fever, 40);
      feverMaxRect = new Rectangle(555, 705, maxFever, 40);
      hpMaxRect = new Rectangle(555, 755, maxHp, 40);
      // hpRectOutline = new Rectangle(XPosition, YPosition, Width, Height);
      // feverRectOutline = new Rectangle(XPosition, YPosition, Width, Height);


      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 35, Height - 120, Color.GRAY);
      HpFever();
      ScoreCircle();
    }

    // !Spelarens rörelse

    // !GÖr så att man läser detta från settings text + kan ändra knapparna
    public override void Update()
    {
      FeverMode();

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
      if (timer == 100f)
      {
        RandomCircleDraw();
        timer = 0f;
      }
    }

    void FeverMode()
    {
      // !Aktiverar Fever
      if (Fever >= MaxFever)
      {
        IsFeverMode = true;
      }
      // !När fever tar slut
      else if (Fever == 0)
      {
        IsFeverMode = false;
        feverTimer = 0;
      }

      // !När Fevermode är akriverad
      if (IsFeverMode)
      {
        feverTimer++;
        if (feverTimer == 5)
        {
          Fever -= 2;
          feverTimer = 0;
        }
      }
    }

    void RandomCircleDraw()
    {
      // !Gör nya stats för cirklarna hela tiden
      Radius = random.Next(40, 70);
      Color = new Color(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20), random.Next(175, 255));
      pos.X = random.Next(690, 800);
      pos.Y = random.Next(80, 120);

      pos2.X = random.Next(690, 800);
      pos2.Y = random.Next(80, 120);

      vector2Set.Add(pos);
      vector2Set.Add(pos2);
    }

    void ScoreCircle()
    {
      Raylib.DrawText(Combo.ToString(), 700, 60, 50, GamePlay.gamePlay.Black);
      Raylib.DrawText("COMBO", 690, 100, 30, GamePlay.gamePlay.Black);
    }

    void HpFever()
    {
      // !Score, hp, etc
      Raylib.DrawText("Score", 10, 80, 50, GamePlay.gamePlay.Black);
      Raylib.DrawText(Score.ToString(), 10, 140, 50, GamePlay.gamePlay.Black);

      Raylib.DrawRectangleRec(hpMaxRect, GamePlay.gamePlay.Black);
      Raylib.DrawRectangleRec(feverMaxRect, GamePlay.gamePlay.Black);
      Raylib.DrawRectangleRec(hpRect, Color.RED);
      Raylib.DrawRectangleRec(feverRect, Color.BLUE);
      // Raylib.DrawRectangleRec(extraRect, Color.GREEN);

      // Raylib.DrawTexture(hpTexture, 540, 755, Color.WHITE);
      // Raylib.DrawTexture(feverTexture, 595, 755, Color.WHITE);
      // Raylib.DrawTexture(hpExtraTexture, 447, 745, Color.WHITE);


      Raylib.DrawText("Fever", 670, 710, 25, GamePlay.gamePlay.White);
      Raylib.DrawText(hp + "/" + maxHp, 645, 760, 25, GamePlay.gamePlay.White);

    }

    // !Vart spelaren hamnar när den slår fienden
    // ?Det är public bara för automatiskt, årkar inte spela själv...
    public void Air()
    {
      YPosition = 200;
    }
    public void Ground()
    {
      YPosition = 400;
    }

    // !GeiminiEnemy har två rectanglar med collision i båda hållen, om spelaren trycker på båda sammtidigt,hamnar spelaren i "mitten"
    public void MiddleAir()
    {
      YPosition = 300;
    }

  }
}
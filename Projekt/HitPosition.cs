using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class HitPosition : Objekt
  {
    // !Kollision
    bool areOverlappingPerfect;
    bool areOverlappingPerfectAUTO;
    bool areOverlappingEarly;
    bool areOverlappingLate;

    // !HitCircle
    Vector2 hitCircle;
    float rotation = 0f;
    float scale = 0.8f;

    // !Random
    Random random = new Random();

    int textSpeed;

    int textYPos;
    public int TextYPos
    {
      get { return textYPos; }
      set { textYPos = value; }
    }

    int textXPos;
    public int TextXPos
    {
      get { return textXPos; }
      set { textXPos = value; }
    }

    float timer;
    public float Timer
    {
      get { return timer; }
      set { timer = value; }
    }

    bool textActive = false;
    public bool TextActive
    {
      get { return textActive; }
      set { textActive = value; }
    }
    //! Texture
    Texture2D hitCircleTexture;

    List<Rectangle> collitionalRectangleList = new List<Rectangle>();

    Rectangle perfektCollitionalRectangle;
    Rectangle perfektCollitionalRectangleAUTO;
    Rectangle greatCollitionalEarly;
    Rectangle greatCollitionalLate;

    bool pressedGreat = false;
    bool pressedPerfect = false;

    // !Alla variablar som inte står ovan tas från klassen Objekt
    public HitPosition(int xPosition, int yPosition)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = 40;
      Height = 40;

      hitCircleTexture = Raylib.LoadTexture("Texture/HitCircle.png");

      hitCircle = new Vector2(XPosition - 10, YPosition - 10);

      perfektCollitionalRectangleAUTO = new Rectangle(XPosition + 10, YPosition, 5, Height);

      perfektCollitionalRectangle = new Rectangle(XPosition, YPosition, Width, Height);
      greatCollitionalEarly = new Rectangle(XPosition + 40, YPosition, Width, Height);
      greatCollitionalLate = new Rectangle(XPosition - 40, YPosition, Width, Height);

      // collitionalRectangleList.Add(perfektCollitionalRectangle);
      // collitionalRectangleList.Add(greatCollitionalEarly);
      // collitionalRectangleList.Add(greatCollitionalLate);


      // for (int i = 0; i < collitionalRectangleList.Count; i++)
      // {
      // }
    }

    // !Animera cirkeln
    public override void Update()
    {
      // rotation += 0.05f;

      // if (scale >= 0.8)
      // {
      //   scale += 0.2f;
      // }

      // if (scale <= 1.2)
      // {
      //   scale -= 0.2f;
      // }
      if (TextActive)
      {
        Timer++;
      }

      if (Timer < 80)
      {
        TextYPos -= textSpeed;
      }
      else
      {
        // !Texten försvinner
        TextActive = false;
        Timer += 0;
        Timer = 0;
        TextYPos = 10000;
        textSpeed = 0;
      }

      textSpeed++;
      if (textSpeed > 2)
      {
        textSpeed = 1;
      }
    }

    // !Kör metoden IsOverlapping om man trycker på knapparna 
    public void HitPressed(Enemy target, Player player)
    {
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) || Raylib.IsKeyPressed(KeyboardKey.KEY_THREE))
      {
        IsOverlapping(target, player);
      }
    }

    // !Kollar collision
    public void IsOverlapping(Enemy target, Player player)
    {
      // ?gör koden bättre...
      areOverlappingPerfectAUTO = Raylib.CheckCollisionRecs(perfektCollitionalRectangleAUTO, target.CollitionalRectangle);
      areOverlappingPerfect = Raylib.CheckCollisionRecs(perfektCollitionalRectangle, target.CollitionalRectangle);
      areOverlappingLate = Raylib.CheckCollisionRecs(greatCollitionalLate, target.CollitionalRectangle);
      areOverlappingEarly = Raylib.CheckCollisionRecs(greatCollitionalEarly, target.CollitionalRectangle);

      // !Om den redan är död, bryr sig inte koden längre
      if (!target.Dead)
      {

        // !Automatiskt speland
        if (areOverlappingEarly)
        {
          EnemyPressed(target, player);
        }

        // !Ger poäng bereonde på vart spelren träffar
        GivePoints(target, player);

        //! Om spelaren missar
        Miss(target, player);
      }
    }


    // !Ritar ut sakerna
    public override void DrawObject()
    {
      Raylib.DrawTextureEx(hitCircleTexture, hitCircle, rotation, scale, Color.WHITE);
      // Raylib.DrawRectangleRec(perfektCollitionalRectangleAUTO, Color.GREEN);
      // Raylib.DrawRectangleRec(perfektCollitionalRectangle, Color.GREEN);
      // Raylib.DrawRectangleRec(greatCollitionalEarly, Color.BLUE);
      // Raylib.DrawRectangleRec(greatCollitionalLate, Color.BLUE);
      if (TextYPos != 0 || TextYPos != 10000 || pressedPerfect)
      {
        DrawTextPointsPerfect();
      }

      else if (TextYPos != 0 || TextYPos != 10000 || pressedGreat)
      {
        DrawTextPointsGreat();
      }
    }

    //! Text när spelaren trycker, för att veta hur precis trycket va
    //? Gör så att det finns kvar mer än 1 frame
    // ?Gör så att dessa är bara en metod
    void DrawTextPointsGreat()
    {
      Raylib.DrawText("GREAT", TextXPos, TextYPos, 40, GamePlay.gamePlay.Black);
    }

    void DrawTextPointsPerfect()
    {
      // TextSpeed += random.Next(10, 20);
      Raylib.DrawText("PERFECT", TextXPos, TextYPos, 40, GamePlay.gamePlay.Black);
    }



    void Miss(Enemy target, Player player)
    {

      if (target.XPosition <= 0 && target.Dead)
      {
        //!När spelaren missar,
        // ?Combo ska få MAXCOMBO
        // ?Miss Texture
        player.Combo = 0;
        player.Hp -= 50;
        target.Dead = true;
      }
    }

    void GivePoints(Enemy target, Player player)
    {
      if (areOverlappingLate || areOverlappingEarly)
      {
        // !Ger mindre poäng
        player.Score += (target.GiveScore / 3) * (player.Combo / 100) / 100;
        pressedGreat = true;
      }

      else if (areOverlappingPerfectAUTO || areOverlappingPerfect)
      {
        // !Ger mer poäng
        player.Score += (target.GiveScore * (player.Combo / 100)) / 100;
        pressedPerfect = true;
      }
    }

    void EnemyPressed(Enemy target, Player player)
    {
      // !Gör så att Spelaren får Fever när den redan är aktiv
      if (!player.IsFeverMode)
      {
        player.Fever += target.GiveFever;
      }

      // !Ökar Combo
      player.Combo++;

      // !Ändrar vart Spelaren är
      PlayerPosition(target, player);

      // !Ritar Texten
      TextActive = true;
      TextXPos = target.XPosition;
      TextYPos = target.YPosition - 50;

      //! Mashenemy, GeiminiEnemy och bossen dör inte
      if (target is MashEnemy || target is Boss || target is GeiminiEnemy)
      {
        return;
      }

      target.DeadMethod();
    }

    void PlayerPosition(Enemy target, Player player)
    {
      // !Spelaren rör bara om enemy lever

      // !Om Enemy target är en mash kommer mash aktiveras
      if (target is MashEnemy)
      {
        player.MiddleAir();
        // ?Ändra på 130 så att det beror på hur mycket som står i Gameplay.cs
        target.TimerMash(130);
      }

      // !Om Enemy target är en geiminiEnemy så hamnar spelaren i "mitten"
      if (target is GeiminiEnemy)
      {
        player.MiddleAir();
        player.Combo++;
        target.IsHurt = true;
      }

      // !Om Enemy target är en Boss så kommer den skadas
      if (target is Boss)
      {
        target.IsHurt = true;
        player.Ground();
      }

      // !Om enemy är uppe i luften och får en kollision
      else if (this.YPosition == 250)
      {
        // ?FIXA DETTA
        if (target is MashEnemy || target is GeiminiEnemy)
        {
          player.MiddleAir();
          return;
        }
        player.Air();
      }

      // !Om enemy är nere och får en kollision
      else if (this.YPosition == 450)
      {
        player.Ground();
      }

    }
  }
}
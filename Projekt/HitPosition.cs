using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class HitPosition : Objekt
  {
    bool areOverlappingPerfect;
    bool areOverlappingEarly;
    bool areOverlappingLate;

    Vector2 hitCircle;
    float rotation = 0f;
    float scale = 0.8f;

    //! Texture
    Texture2D hitCircleTexture;

    List<Rectangle> collitionalRectangleList = new List<Rectangle>();

    Rectangle perfektCollitionalRectangle;
    Rectangle greatCollitionalEarly;
    Rectangle greatCollitionalLate;

    // !Alla variablar som inte står ovan tas från klassen Objekt
    public HitPosition(int xPosition, int yPosition)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = 20;
      Height = 20;

      hitCircleTexture = Raylib.LoadTexture("Texture/HitCircle.png");

      hitCircle = new Vector2(XPosition - 10, YPosition - 10);

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
      areOverlappingPerfect = Raylib.CheckCollisionRecs(perfektCollitionalRectangle, target.CollitionalRectangle);
      areOverlappingLate = Raylib.CheckCollisionRecs(greatCollitionalLate, target.CollitionalRectangle);
      areOverlappingEarly = Raylib.CheckCollisionRecs(greatCollitionalEarly, target.CollitionalRectangle);

      if (areOverlappingPerfect || areOverlappingEarly || areOverlappingLate)
      {
        player.Fever += target.GiveFever;
        player.Combo++;
        // target.Bounce();
        // ?Gör så att target inte finns kvar
      }

      if (areOverlappingPerfect)
      {
        player.Score += target.GiveScore * (player.Combo / 10);
        DrawTextPoints("PERFECT", target);
      }
      if (areOverlappingLate || areOverlappingEarly)
      {
        // !Ger mindre poäng
        player.Score += (target.GiveScore / 3) * (player.Combo / 10);
        DrawTextPoints("GREAT", target);
      }
    }

    //! Text när spelaren trycker, för att veta hur precis trycket va
    //? Gör så att det finns kvar mer än 1 frame
    public void DrawTextPoints(String text, Enemy target)
    {
      Raylib.DrawText(text, target.XPosition, target.YPosition - 30, 30, Color.BLUE);
    }

    // !Ritar ut sakerna
    public override void DrawObject()
    {
      // Raylib.DrawRectangleRec(perfektCollitionalRectangle, Color.GREEN);
      // Raylib.DrawRectangleRec(greatCollitionalEarly, Color.BLUE);
      // Raylib.DrawRectangleRec(greatCollitionalLate, Color.BLUE);

      Raylib.DrawTextureEx(hitCircleTexture, hitCircle, rotation, scale, Color.WHITE);
    }

  }
}
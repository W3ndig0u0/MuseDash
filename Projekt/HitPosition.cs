using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public class HitPosition : Objekt
  {
    bool areOverlapping;
    Vector2 hitCircle;
    int rotation = 0;

    //! Texture
    Texture2D hitCircleTexture;

    List<Rectangle> collitionalRectangleList = new List<Rectangle>();

    Rectangle perfektCollitionalRectangle;
    Rectangle greatCollitionalEarly;
    Rectangle greatCollitionalLate;

    // !Alla variablar som inte står ovan tas från klassen Objekt
    public HitPosition(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      hitCircleTexture = Raylib.LoadTexture("Texture/HitCircle.png");

      hitCircle = new Vector2(XPosition - 10, YPosition - 10);

      perfektCollitionalRectangle = new Rectangle(XPosition, YPosition, Width, Height);
      greatCollitionalEarly = new Rectangle(XPosition + 40, YPosition, Width, Height);
      greatCollitionalLate = new Rectangle(XPosition - 40, YPosition, Width, Height);

      collitionalRectangleList.Add(perfektCollitionalRectangle);
      collitionalRectangleList.Add(greatCollitionalEarly);
      collitionalRectangleList.Add(greatCollitionalLate);


      for (int i = 0; i < collitionalRectangleList.Count; i++)
      {
        // areOverlapping = Raylib.CheckCollisionRecs(collitionalRectangleList[i], CollitionalRectangle);
      }
    }

    // !Animera cirkeln
    public override void Update()
    {
      // rotation++;
      if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
      {
        HitPressed();
      }
    }

    void HitPressed()
    {

    }

    // !Ritar ut sakerna
    public override void DrawObject()
    {
      // Raylib.DrawRectangleRec(perfektCollitionalRectangle, Color.GREEN);
      // Raylib.DrawRectangleRec(greatCollitionalEarly, Color.BLUE);
      // Raylib.DrawRectangleRec(greatCollitionalLate, Color.BLUE);

      Raylib.DrawTextureEx(hitCircleTexture, hitCircle, (float)rotation, 1f, Color.WHITE);

    }

  }
}
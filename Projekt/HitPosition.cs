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
    Vector2 hitCircleMini;
    int rotation;

    List<Rectangle> collitionalRectangleList = new List<Rectangle>();

    Rectangle perfektCollitionalRectangle;
    Rectangle greatCollitionalEarly;
    Rectangle greatCollitionalLate;

    // !Alla variablar som inte står ovan tas från klassen Objekt
    public HitPosition(int xPosition, int yPosition, int width, int height, Rectangle CollitionalRectangle)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      hitCircle = new Vector2(XPosition + 20, YPosition + 20);
      hitCircleMini = new Vector2(XPosition + 20, YPosition + 20);

      perfektCollitionalRectangle = new Rectangle(XPosition, YPosition, Width, Height);
      greatCollitionalEarly = new Rectangle(XPosition + 40, YPosition, Width, Height);
      greatCollitionalLate = new Rectangle(XPosition - 40, YPosition, Width, Height);

      collitionalRectangleList.Add(perfektCollitionalRectangle);
      collitionalRectangleList.Add(greatCollitionalEarly);
      collitionalRectangleList.Add(greatCollitionalLate);


      areOverlapping = Raylib.CheckCollisionRecs(perfektCollitionalRectangle, CollitionalRectangle);
      DrawObject();
      Update();
    }

    // !Ritar ut sakerna
    public override void DrawObject()
    {
      Raylib.DrawRectangleRec(perfektCollitionalRectangle, Color.GREEN);
      Raylib.DrawRectangleRec(greatCollitionalEarly, Color.BLUE);
      Raylib.DrawRectangleRec(greatCollitionalLate, Color.BLUE);
    }

    // !Animera cirkeln
    public override void Update()
    {
      Raylib.DrawCircleV(hitCircle, Width / 2, Color.BROWN);

      //! Texture
      Texture2D hitCircleTexture = LoadTexture("Texture/HitCircle.png");

      int frameWidth = hitCircleTexture.width / 6;
      int frameHeight = hitCircleTexture.height;

      Rectangle sourceRec = new Rectangle(0.0f, 0.0f, (float)frameWidth, (float)frameHeight);
      Rectangle destRec = new Rectangle(1600 / 2.0f, 800 / 2.0f, frameWidth * 2.0f, frameHeight * 2.0f);
      Raylib.DrawTexturePro(hitCircleTexture, sourceRec, destRec, hitCircle, (float)rotation, Color.WHITE);
      rotation++;
    }

  }
}
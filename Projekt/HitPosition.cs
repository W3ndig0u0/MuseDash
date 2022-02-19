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

    List<Rectangle> collitionalRectangleList = new List<Rectangle>();

    Rectangle perfektCollitionalRectangle;
    Rectangle greatCollitionalEarly;
    Rectangle greatCollitionalLate;

    // !Alla variablar som inte står ovan tas från klassen Objekt
    public HitPosition(int xPosition, int yPosition, int width, int height, Objekt target)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      hitCircle = new Vector2(XPosition + 25, YPosition + 25);
      hitCircleMini = new Vector2(XPosition + 20, YPosition + 20);

      perfektCollitionalRectangle = new Rectangle(XPosition, YPosition, Width, Height);
      greatCollitionalEarly = new Rectangle(XPosition + 40, YPosition, Width, Height);
      greatCollitionalLate = new Rectangle(XPosition - 40, YPosition, Width, Height);

      collitionalRectangleList.Add(perfektCollitionalRectangle);
      collitionalRectangleList.Add(greatCollitionalEarly);
      collitionalRectangleList.Add(greatCollitionalLate);


      areOverlapping = Raylib.CheckCollisionRecs(perfektCollitionalRectangle, target.CollitionalRectangle);
      DrawObject();
    }

    public override void DrawObject()
    {
      Raylib.DrawRectangleRec(perfektCollitionalRectangle, Color.GREEN);
      Raylib.DrawRectangleRec(greatCollitionalEarly, Color.BLUE);
      Raylib.DrawRectangleRec(greatCollitionalLate, Color.BLUE);

      //   Raylib.DrawCircleV(hitCircle, Width / 2, Color.BROWN);

      //   Raylib.DrawCircleV(hitCircleMini, Width - 10, Color.BLUE);
      //   Raylib.DrawCircleV(hitCircleMini, Width - 20, Color.BLUE);
      //   Raylib.DrawCircleV(hitCircleMini, Width - 30, Color.BLUE);
    }

    public override void Update()
    {
    }

  }
}
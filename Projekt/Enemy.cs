using System;
using Raylib_cs;

namespace Projekt
{
  public class Enemy : Objekt
  {

    public Enemy(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition - 15;
      XPosition = xPosition;
      Width = width;
      Height = height;
    }

    public override void DrawObject()
    {
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);
      CollitionalRectangle = new Rectangle(XPosition, YPosition + 20, Width - 35, Height - 35);

      Raylib.DrawRectangleRec(Sprite, Color.BLACK);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);

      // !600 är vart Marken beffiner  sig
      Raylib.DrawEllipse(XPosition + 40, 600, Width - 20, Height - 40, Color.GRAY);

    }

    public override void Update()
    {
      ObjektList.Add(CollitionalRectangle);
      XPosition -= 5;
    }

  }
}
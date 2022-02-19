using System;
using Raylib_cs;

namespace Projekt
{
  public class Enemy : Objekt
  {

    public Enemy(int xPosition, int yPosition, int width, int height)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;
      Sprite = new Rectangle(XPosition, YPosition, Width, Height);

      // ?Gör så att det inte är 35 utan hälften av fiendens storlek
      CollitionalRectangle = new Rectangle(XPosition, YPosition, Width - 35, Height - 35);

      // !600 är vart marken beffiner sig
      Shadow = new Rectangle(XPosition, 600, Width, Height);
      ObjektList.Add(CollitionalRectangle);

      DrawObject();
      Update();
    }

    public override void DrawObject()
    {
      Raylib.DrawRectangleRec(Sprite, Color.BLUE);
      Raylib.DrawRectangleRec(CollitionalRectangle, Color.GREEN);
    }

    public override void Update()
    {
      // sprite.x--;
      // collitionalRectangle.x--;
      // shadow.x--;
    }
  }
}
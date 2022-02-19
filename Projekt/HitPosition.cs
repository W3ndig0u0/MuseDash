using System;
using Raylib_cs;

namespace Projekt
{
  public class HitPosition : Objekt
  {
    // !Allt tas från arven 
    public HitPosition(int xPosition, int yPosition, int width, int height, Objekt target)
    {
      YPosition = yPosition;
      XPosition = xPosition;
      Width = width;
      Height = height;

      CollitionalRectangle = new Rectangle(xPosition, yPosition, width, height);
      //   areOverlapping = Raylib.GetCollisionRec(this.collitionalRectangle, target.CollitionalRectangle);
      RenderHitPosition();
    }

    void RenderHitPosition()
    {

    }
  }
}
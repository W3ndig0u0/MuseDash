using System;
using Raylib_cs;

namespace Projekt
{
  public abstract class Objekt
  {
    int speed;
    public int Speed
    {
      get { return speed; }
      set { speed = value; }
    }

    int yPosition;
    public int YPosition
    {
      get { return yPosition; }
      set { yPosition = value; }
    }

    int xPosition;
    public int XPosition
    {
      get { return xPosition; }
      set { xPosition = value; }
    }

    int width;
    public int Width
    {
      get { return width; }
      set { width = value; }
    }

    int height;
    public int Height
    {
      get { return height; }
      set { height = value; }
    }


    Rectangle collitionalRectangle;
    public Rectangle CollitionalRectangle
    {
      get { return collitionalRectangle; }
      set { collitionalRectangle = value; }
    }

    Rectangle Sprite;
  }

}
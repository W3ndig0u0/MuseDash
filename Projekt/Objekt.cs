using System.Collections.Generic;
using Raylib_cs;

namespace Projekt
{
  public abstract class Objekt
  {

    // !Lista över alla Collisions för att kolla collisionen lättare
    List<Rectangle> objektList = new List<Rectangle>();
    public List<Rectangle> ObjektList
    {
      get { return objektList; }
      set { objektList = value; }
    }

    int giveScore;
    public int GiveScore
    {
      get { return giveScore; }
      set { giveScore = value; }
    }

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

    Rectangle sprite;
    public Rectangle Sprite
    {
      get { return sprite; }
      set { sprite = value; }
    }

    public abstract void DrawObject();
    public abstract void Update();



  }

}
using System;
using System.Numerics;
using Raylib_cs;


namespace Projekt
{
  abstract public class Button
  {
    // !De viktigaste variablerna för en knapp
    // !Det är en abstrakt klass pga man inte kommer initsiera klassen + classen inte kommer ha en "kropp"
    int xPosition;
    public int XPosition
    {
      get { return xPosition; }
      set { xPosition = value; }
    }

    int yPosition;
    public int YPosition
    {
      get { return yPosition; }
      set { yPosition = value; }
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

    // !Man vill ändra ButtonColor, ändrar detta senare om jag orkar :), ButtonColor följer inte camelCase, pga, det kommer krocka senare
    public Color ButtonColor;

    Rectangle buttonRectangle;
    public Rectangle ButtonRectangle
    {
      get { return buttonRectangle; }
      set { buttonRectangle = value; }
    }

    Vector2 mousePos;
    public Vector2 MousePos
    {
      get { return mousePos; }
      set { mousePos = value; }
    }

    bool areOverlapping;
    public bool AreOverlapping
    {
      get { return areOverlapping; }
      set { areOverlapping = value; }
    }

    abstract public void Update();
    abstract public void DrawButton();


  }
}
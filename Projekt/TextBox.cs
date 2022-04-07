using System;
using System.Numerics;
using Raylib_cs;

namespace Projekt
{
  public class TextBox
  {
    Rectangle rect;
    public Rectangle Rect
    {
      get { return rect; }
      set { rect = value; }
    }


    Vector2 mousePos;
    // !Hårdkodar storleken
    int width = 800;
    int height = 70;

    bool selected = false;
    string textInput;
    int X;
    int Y;

    string textBefore;
    public string TextBefore
    {
      get { return textBefore; }
      set { textBefore = value; }
    }

    public TextBox(string textBefore, int x, int y)
    {
      X = x;
      Y = y;
      TextBefore = textBefore;

      Rect = new Rectangle(x, y, width, height);
      mousePos = Raylib.GetMousePosition();
    }

    public void DrawBox()
    {
      // !Ritar Rectangeln och texten
      Raylib.DrawRectangleRec(rect, Color.WHITE);
      Raylib.DrawRectangleLinesEx(rect, 1, Color.BLACK);
      Raylib.DrawText(TextBefore, X, Y, 30, Color.BLACK);
    }

  }
}
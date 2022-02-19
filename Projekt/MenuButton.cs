using System;
using System.Numerics;
using Raylib_cs;

namespace Projekt
{
  public class MenuButton
  {
    int XPosition;
    int YPosition;
    int Width;
    int Height;

    Color ButtonColor;

    Vector2 mousePos;
    Sound clickSound;
    Rectangle button;
    bool areOverlapping;


    public MenuButton(int xPosition, int yPosition, int width, int height, Color buttonColor)
    {
      XPosition = xPosition;
      YPosition = yPosition;
      Width = width;
      Height = height;
      ButtonColor = buttonColor;

      button = new Rectangle(xPosition, yPosition, width, height);
      mousePos = Raylib.GetMousePosition();
      areOverlapping = Raylib.CheckCollisionPointRec(mousePos, this.button);

      Update();
      DrawMenuButton();
    }

    // !Ritar ut Knappen
    void DrawMenuButton()
    {
      Raylib.DrawRectangleRec(button, ButtonColor);
    }

    // !Animation för Knappen
    void Update()
    {
      if (areOverlapping)
      {
        XPosition -= 12;
        ButtonColor.a = 200;
        // Raylib.PlaySound(clickSound);

        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
        {
          // Raylib.PlaySound(clickSound);
          ButtonColor.a = 255;
        }
      }

      else
      {
        XPosition -= 6;
        ButtonColor.a = 170;
      }

    }
  }
}
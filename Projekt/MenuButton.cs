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
    Scene Scene;

    public MenuButton(int xPosition, int yPosition, int width, int height, Color buttonColor, Scene scene)
    {
      XPosition = xPosition;
      YPosition = yPosition;
      Width = width;
      Height = height;
      ButtonColor = buttonColor;
      Scene = scene;
      clickSound = Raylib.LoadSound("Sound/SoundEffect/BtnClickSound.mp3");

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
          ButtonColor.a = 255;

          // !"Återanvinner" CurrentScene som InitGame skapade, vill inte att varje knapp ska skapa en ny current Scene
          InitGame.currentScene.AddScene(Scene);
          InitGame.draw.RenderScene(Scene);
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
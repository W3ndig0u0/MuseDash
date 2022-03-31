using System;
using System.Numerics;
using Raylib_cs;

namespace Projekt
{
  public class MenuButton : Button
  {

    Scene Scene;
    Scene LastScene;
    string Text;

    public MenuButton(int xPosition, int yPosition, int width, int height, Color buttonColor, Scene scene, string text, Scene lastScene)
    {
      XPosition = xPosition;
      YPosition = yPosition;
      Width = width;
      Height = height;
      ButtonColor = buttonColor;
      Scene = scene;
      Text = text;
      LastScene = lastScene;

      // clickSound = Raylib.LoadSound("Sound/SoundEffect/BtnClickSound.mp3");
      ButtonRectangle = new Rectangle(xPosition, yPosition, width, height);
      MousePos = Raylib.GetMousePosition();
      AreOverlapping = Raylib.CheckCollisionPointRec(MousePos, this.ButtonRectangle);

      Update();
      DrawButton();
    }

    // !Ritar ut Knappen
    public override void DrawButton()
    {
      Raylib.DrawRectangleRec(ButtonRectangle, ButtonColor);
      Raylib.DrawText(Text, XPosition + 50, YPosition + 30, 20, Color.WHITE);
    }

    // !Animation för Knappen
    public override void Update()
    {
      if (AreOverlapping)
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
        XPosition += 8;
        ButtonColor.a = 170;
      }

    }
  }
}
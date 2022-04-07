using System;
using System.Numerics;
using Raylib_cs;

namespace Projekt
{
  public class MenuButton : Button
  {

    Scene scene;
    public Scene Scene
    {
      get { return scene; }
      set { scene = value; }
    }

    string Text;

    public Rectangle buttonRectangle;

    public MenuButton(int xPosition, int yPosition, int width, int height, Color buttonColor, string text, Scene scene)
    {
      XPosition = xPosition;
      YPosition = yPosition;
      Width = width;
      Height = height;
      ButtonColor = buttonColor;
      Text = text;
      Scene = scene;

      // clickSound = Raylib.LoadSound("Sound/SoundEffect/BtnClickSound.mp3");
      buttonRectangle = new Rectangle(xPosition, yPosition, width, height);
      MousePos = Raylib.GetMousePosition();
      AreOverlapping = Raylib.CheckCollisionPointRec(MousePos, buttonRectangle);

      Update();
      DrawButton();
    }

    // !Ritar ut Knappen
    public override void DrawButton()
    {
      Raylib.DrawRectangleRec(buttonRectangle, ButtonColor);
      // !Så att texten inte är utanför boxen om knappen är liten
      if (Width <= 100)
      {
        Raylib.DrawText(Text, XPosition + 10, YPosition + 20, 12, Color.WHITE);
      }
      else
      {
        Raylib.DrawText(Text, XPosition + 50, YPosition + 30, 20, Color.WHITE);
      }
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
          Console.WriteLine("scene: " + scene);
          ButtonColor.a = 255;
          // !Om scene är inte är tom
          if (scene != null)
          {
            // !"Återanvinner" CurrentScene som InitGame skapade, vill inte att varje knapp ska skapa en ny current Scene
            InitGame.currentScene.AddScene(scene);
            InitGame.draw.RenderScene(scene);
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
}
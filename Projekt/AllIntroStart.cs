using System;

namespace Projekt
{
  public class AllIntroStart
  {
    // !Alla intro scener initsieras
    MenuScene menuScene = new MenuScene();

    public Loading loadingScene = new Loading();
    Loading loadingScene2 = new Loading();
    Loading loadingScene3 = new Loading();

    public void InsertLoadingScene()
    {

      // !Vilken scene kommer efter Loading
      loadingScene3.NextScene = menuScene;
      loadingScene2.NextScene = loadingScene3;
      loadingScene.NextScene = loadingScene2;

      // !Berättar vilken bild loading ska ha
      loadingScene3.ImgFileName = "Texture/HidePeiLogo.png";
      loadingScene2.ImgFileName = "Texture/Logo5.png";
      loadingScene.ImgFileName = "Texture/EarphonesIntro.png";
    }
  }
}
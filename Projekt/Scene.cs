using System;
using Raylib_cs;

namespace Projekt
{

  // !Behöver inte kod + initsitaras, så det är en abstrakt klass
  abstract public class Scene
  {
    //! Säger till CurrentScene, vad den ska rita
    abstract public void WhatToDraw();
    abstract public void Update();

  }
}
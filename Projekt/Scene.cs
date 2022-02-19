using System;
using Raylib_cs;

namespace Projekt
{
  abstract public class Scene
  {
    //! Säger till Classen Draw, vad den ska rita
    
    abstract public void WhatToDraw(Color c);

  }
}
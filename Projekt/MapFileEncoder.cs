using System;
using System.IO;

namespace Projekt
{
  public class MapFileEncoder
  {
    public string[] fileInfo;
    string fileName = "MapFile.txt";
    string text = "New Game;0;0";
    int maxFile = 1;

    public void CheckFile()
    {
      //! kollar om filen finns
      if (File.Exists(fileName))
      {
        fileInfo = File.ReadAllLines(fileName);
        for (int i = 0; i < fileInfo.Length; i++)
        {
          fileInfo[i] = text;
        }
      }

      //! om filen inte finns, skapas en ny fil
      else
      {
        fileInfo = new string[maxFile];
        for (int i = 0; i < fileInfo.Length; i++)
        {
          fileInfo[i] = text;
        }
        File.WriteAllLines(fileName, fileInfo);
        Console.Clear();
        Console.WriteLine("Tamogotchi SaveFile.txt hittades inte:");
        Console.WriteLine("En ny Tamogotchi SaveFile.txt Skapas:");
        Console.WriteLine("Vad ska Tamogotchins namn vara?:");
        string namn = Console.ReadLine();
        Console.WriteLine($"Tamogotchin heter nu {namn}.");
        File.WriteAllText("Tamogotchi SaveFile.txt", $"{namn};0;0");
        Console.WriteLine("Tryck på [ENTER] För att Fortsätta.");
        Console.ReadLine();
      }
    }

    //! läser vad som står i filen
    public void SafeFileReadFile()
    {
      fileInfo = File.ReadAllLines(fileName);
      for (int i = 0; i < fileInfo.Length; i++)
      {
        string[] specefikFile = fileInfo[i].Split(';');
        string fileName = specefikFile[0];
        int filePetHunger = int.Parse(specefikFile[1]);
        int filePetBoredome = int.Parse(specefikFile[2]);
        Console.WriteLine($"Save File Nr {i + 1}, FileName: {fileName}, (Hunger: {filePetHunger}, Boredome: {filePetBoredome})");
      }
    }

  }
}
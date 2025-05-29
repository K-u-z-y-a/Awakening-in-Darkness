using System;
using System.Collections.Generic;
using System.Text;

public static class Arts
{
    public static readonly string Lantern = @"
       ,-.
      (   )
       \ /
      _|=|_
     |_____|
    ";

    public static readonly string Door = @"
      ██████
    ██      ██
    █  ??  █
    ██      ██
      ██████
    ";
    public static void ShowLantern()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
          ▄▄
         █▀▀█
        █    █
        █ ██ █
        █    █
         █▄▄█
        ");
        Console.ResetColor();
    }
}
using System;
using System.Collections.Generic;

namespace Awakening_in_Darkness.Core
{
    public static class DialogueSystem
    {
        public static void StartDialogue(Npc npc)
        {
            Logger.Log($"Начат диалог с {npc.Name}");

            foreach (var line in npc.DialogueLines)
            {
                UI.PrintWithColor($"{npc.Name}: {line.Text}", line.Color);

                if (line.Choices.Count > 0)
                {
                    UI.ShowChoices(line.Choices);
                    string choice = Console.ReadLine();
                    // Обработка выбора
                }
            }
        }
    }

    public class Npc
    {
        public string Name { get; set; }
        public List<DialogueLine> DialogueLines { get; set; }
    }

    public class DialogueLine
    {
        public string Text { get; set; }
        public ConsoleColor Color { get; set; }
        public List<string> Choices { get; set; } = new List<string>();
    }
}
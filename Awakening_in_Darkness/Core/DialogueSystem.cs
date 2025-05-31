using System;
using System.Collections.Generic;

namespace Awakening_in_Darkness.Core
{
    public static class DialogueSystem
    {
        // Новая структура для вариантов выбора
        public class DialogueChoice
        {
            public string Text { get; set; }
            public Action OnSelect { get; set; }
        }

        public class DialogueLine
        {
            public string Text { get; set; }
            public ConsoleColor Color { get; set; } = ConsoleColor.Gray;
            public List<DialogueChoice> Choices { get; set; } = new List<DialogueChoice>();
        }

        public class Npc
        {
            public string Name { get; set; }
            public List<DialogueLine> DialogueLines { get; set; } = new List<DialogueLine>();
        }

        public static void StartDialogue(Npc npc)
        {
            if (npc == null || npc.DialogueLines.Count == 0)
            {
                Logger.Log($"Ошибка: диалог с NPC '{npc?.Name}' не содержит реплик.");
                return;
            }

            Logger.Log($"Начат диалог с {npc.Name}");

            foreach (var line in npc.DialogueLines)
            {
                // Вывод текста NPC
                UI.PrintWithColor($"{npc.Name}: {line.Text}", line.Color);

                // Обработка выбора, если есть варианты
                if (line.Choices.Count > 0)
                {
                    HandleChoices(line.Choices);
                }
                else
                {
                    UI.WaitForInput();
                }
            }
        }

        private static void HandleChoices(List<DialogueChoice> choices)
        {
            var choiceTexts = new List<string>();
            for (int i = 0; i < choices.Count; i++)
            {
                choiceTexts.Add($"{i + 1}. {choices[i].Text}");
            }

            UI.ShowChoices(choiceTexts);

            // Обработка ввода с валидацией
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selectedIndex) &&
                    selectedIndex > 0 &&
                    selectedIndex <= choices.Count)
                {
                    choices[selectedIndex - 1].OnSelect?.Invoke();
                    break;
                }
                UI.InvalidInput();
            }
        }
    }
}
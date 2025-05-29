using System;
using System.Collections.Generic;
using Awakening_in_Darkness.Core;

namespace Awakening_in_Darkness.Npcs
{
    public static class AlchemistGhost
    {
        public static void Initialize()
        {
            var ghost = new Npc
            {
                Name = "Призрак Алхимика",
                DialogueLines = new List<DialogueLine>
        {
            new DialogueLine
            {
                Text = "Ты наконец пробудился... Лабиринт ждёт.",
                Color = ConsoleColor.Cyan
            },
            new DialogueLine
            {
                Text = "Выбери путь мудрости, или повтори мою ошибку.",
                Color = ConsoleColor.Cyan,
                Choices = new List<string> // Явно инициализируем List<string>
                {
                    "1. Спросить об ошибке",
                    "2. Уйти"
                }
            }
        }
            };
            DialogueSystem.StartDialogue(ghost);
        }
    }
}
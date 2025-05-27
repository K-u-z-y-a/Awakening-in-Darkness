using System;
using System.Collections.Generic;
using Пробуждение_Во_Тьме.Core;

namespace Пробуждение_Во_Тьме.Npcs
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
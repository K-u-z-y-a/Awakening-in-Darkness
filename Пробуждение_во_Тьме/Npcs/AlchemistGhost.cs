using System;
using System.Collections.Generic;

namespace Пробуждение_Во_Тьме.Npcs
{
    public static class AlchemistGhost
    {
        public static void Initialize()
        {
            var ghost = new Core.Npc
            {
                Name = "Призрак Алхимика",
                DialogueLines = new List<Core.DialogueLine>
                {
                    new Core.DialogueLine
                    {
                        Text = "Ты наконец пробудился... Лабиринт ждёт.",
                        Color = ConsoleColor.Cyan
                    },
                    new Core.DialogueLine
                    {
                        Text = "Выбери путь мудрости, или повтори мою ошибку.",
                        Color = ConsoleColor.Cyan,
                        Choices = { "1. Спросить об ошибке", "2. Уйти" }
                    }
                }
            };

            Core.DialogueSystem.StartDialogue(ghost);
        }
    }
}
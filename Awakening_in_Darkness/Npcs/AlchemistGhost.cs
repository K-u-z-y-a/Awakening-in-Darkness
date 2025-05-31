using System;
using System.Collections.Generic;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Locations;

namespace Awakening_in_Darkness.Npcs
{
    public static class AlchemistGhost
    {
        public static void Initialize()
        {
            var ghost = new DialogueSystem.Npc
            {
                Name = "Призрак Алхимика",
                DialogueLines = new List<DialogueSystem.DialogueLine>
                {
                    new DialogueSystem.DialogueLine
                    {
                        Text = "Ты наконец пробудился... Лабиринт ждёт.",
                        Color = ConsoleColor.Cyan
                    },
                    new DialogueSystem.DialogueLine
                    {
                        Text = "Выбери путь мудрости, или повтори мою ошибку.",
                        Color = ConsoleColor.Cyan,
                        Choices = new List<DialogueSystem.DialogueChoice>
                        {
                            new DialogueSystem.DialogueChoice
                            {
                                Text = "Спросить об ошибке",
                                OnSelect = RevealSecret
                            },
                            new DialogueSystem.DialogueChoice
                            {
                                Text = "Уйти",
                                OnSelect = () => Corridor.Enter()
                            }
                        }
                    }
                }
            };
            DialogueSystem.StartDialogue(ghost);
        }

        private static void RevealSecret()
        {
            UI.PrintWithColor("Призрак: 'Я пытался создать эликсир бессмертия... Но стал этим!'",
                            ConsoleColor.Cyan);
            UI.WaitForInput();
        }
    }
}
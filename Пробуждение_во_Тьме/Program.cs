using System;
using Пробуждение_Во_Тьме.Locations;
using Пробуждение_Во_Тьме.Core;

namespace Пробуждение_Во_Тьме
{
    class Program
    {
        static void Main()
        {
            // Настройка логгера
            Logger.ClearLog();
            Logger.Log("=== Игра запущена ===");

            try
            {
                // Запуск игры
                Console.Title = "Пробуждение во Тьме";
                StartRoom.Enter(); // Используем значение по умолчанию ("начало игры")
            }
            catch (Exception ex)
            {
                // Логирование критических ошибок
                Logger.Log($"КРАШ: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Игра завершилась с ошибкой. Смотрите game_log.txt");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
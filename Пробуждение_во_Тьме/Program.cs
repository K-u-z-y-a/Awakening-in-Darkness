using System;
using Пробуждение_Во_Тьме.Core;
using Пробуждение_Во_Тьме.Locations;

namespace Пробуждение_Во_Тьме
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Пробуждение во Тьме";

            try
            {
                while (true) // Бесконечный цикл
                {
                    StartRoom.Enter();

                    // Добавляем паузу перед очисткой
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"КРИТИЧЕСКАЯ ОШИБКА: {ex}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Игра завершилась с ошибкой: {ex.Message}");
                Console.WriteLine("Подробности в game_log.txt");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
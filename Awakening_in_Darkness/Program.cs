using System;
using System.Text;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Locations;

namespace Awakening_in_Darkness
{
    class Program
    {
        static void Main()
        {
            // Настройки консоли
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
            Console.BufferWidth = 100;
            Console.BufferHeight = 1000;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Пробуждение во Тьме";

            try
            {
                // Убираем начальное ожидание и сразу запускаем игру
                StartRoom.Enter();

                while (true) // Основной игровой цикл
                {
                    // Обработка ввода происходит внутри StartRoom/Corridor
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
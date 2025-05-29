using System;
using System.Text;
using Awakening_in_Darkness.Core;
using Awakening_in_Darkness.Locations;

namespace Пробуждение_Во_Тьме
{
    class Program
    {
        static void Main()
        {
            // Устанавливаем размеры (ширина x высота в символах)
            Console.WindowWidth = 100;  // Ширина
            Console.WindowHeight = 30;  // Высота

            // Увеличиваем буфер, чтобы можно было скроллить
            Console.BufferWidth = 100;
            Console.BufferHeight = 1000;
            Console.OutputEncoding = Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            // Включаем Unicode для символов
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
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
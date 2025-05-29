using System;
using System.IO;

namespace Awakening_in_Darkness.Core
{
    public static class Logger
    {
        private static readonly string _logPath = "game_log.txt"; // Путь к файлу логов

        public static void Log(string message)
        {
            try
            {
                // Формат: [Дата] Сообщение
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n";

                // Записываем в файл (дописываем, если файл существует)
                File.AppendAllText(_logPath, logMessage);
            }
            catch (Exception ex)
            {
                // Если что-то пошло не так (например, нет прав на запись)
                Console.WriteLine($"Ошибка логгера: {ex.Message}");
            }
        }

        public static void ClearLog()
        {
            if (File.Exists(_logPath))
            {
                File.Delete(_logPath);
            }
        }
    }
}
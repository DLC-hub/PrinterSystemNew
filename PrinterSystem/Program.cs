using System;
using PrinterSystem.Models;
using PrinterSystem.Mediator;

namespace PrinterSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ ОЧЕРЕДЬЮ ПЕЧАТИ ===\n");

            var printer = new Printer();
            var queue = new PrintQueue();
            var logger = new Logger();
            var mediator = new PrintSystemMediator(printer, queue, logger);
            var dispatcher = new Dispatcher();
            dispatcher.SetMediator(mediator);

            var doc1 = new Document("Отчёт_2025");
            var doc2 = new Document("Договор_подряда");
            var doc3 = new Document("График_проекта");

            doc1.SetMediator(mediator);
            doc2.SetMediator(mediator);
            doc3.SetMediator(mediator);

            // 1. Добавляем документы в очередь
            Console.WriteLine("--- Добавление документов в очередь ---");
            doc1.AddToQueue();
            doc2.AddToQueue();
            doc3.AddToQueue();

            // 2. Печать первого документа (успешно)
            Console.WriteLine("\n--- Запуск печати (первый документ) ---");
            dispatcher.CommandProcessQueue();   // печатает doc1

            // 3. Печать второго документа с ошибкой
            Console.WriteLine("\n--- Имитация ошибки принтера для второго документа ---");
            printer.SimulateFailure = true;     // включаем ошибку
            dispatcher.CommandProcessQueue();   // печатает doc2 → ошибка

            // 4. Сброс ошибочного документа и повторная отправка
            Console.WriteLine("\n--- Сброс ошибочного документа и повтор ---");
            doc2.Reset();                       // Error -> New
            doc2.AddToQueue();                  // снова в очередь
            dispatcher.CommandProcessQueue();   // печатает doc2 (успешно)

            // 5. Печать третьего документа
            Console.WriteLine("\n--- Печать третьего документа ---");
            dispatcher.CommandProcessQueue();   // печатает doc3

            // 6. Попытка печати пустой очереди
            Console.WriteLine("\n--- Попытка печати при пустой очереди ---");
            dispatcher.CommandProcessQueue();   // очередь пуста

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА ===");
        }
    }
}
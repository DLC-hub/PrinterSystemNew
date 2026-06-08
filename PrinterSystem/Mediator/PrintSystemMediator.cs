using System;
using PrinterSystem.Models;
using PrinterSystem.States;

namespace PrinterSystem.Mediator
{
    public class PrintSystemMediator : IMediator
    {
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;

        public PrintSystemMediator(Printer printer, PrintQueue queue, Logger logger)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;

            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
        }

        public void Notify(Colleague sender, string ev, Document document = null)
        {
            switch (ev)
            {
                case "AddToQueue":
                    _queue.EnqueueItem(document);
                    break;

                case "Enqueued":
                    _logger.WriteMessage($"Документ '{document.Title}' помещён в очередь.");
                    break;

                case "RequestPrint":
                    document.SetState(new PrintingState());
                    _logger.WriteMessage($"Начало печати документа '{document.Title}'.");
                    _printer.StartPrint(document);
                    break;

                case "ProcessQueue":
                    if (_queue.IsEmpty)
                    {
                        _logger.WriteMessage("Очередь пуста.");
                        return;
                    }
                    var nextDoc = _queue.DequeueItem();
                    nextDoc.SetMediator(this);
                    nextDoc.Print();
                    break;

                case "PrintSuccess":
                    document.CompletePrinting();
                    _logger.WriteMessage($"Успешно напечатан документ '{document.Title}'.");
                    break;

                case "PrintFailed":
                    document.FailPrinting();
                    _logger.WriteMessage($"ОШИБКА печати документа '{document.Title}'.");
                    break;
            }
        }
    }
}
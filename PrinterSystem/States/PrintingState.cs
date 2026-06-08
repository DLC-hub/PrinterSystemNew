using System;
using PrinterSystem.Models;

namespace PrinterSystem.States
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine("[FSM: Printing] Документ уже печатается, повторная печать невозможна.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine("[FSM: Printing] Нельзя добавить в очередь — документ уже печатается.");
        }

        public void CompletePrinting(Document document)
        {
            document.SetState(new DoneState());
            Console.WriteLine("[FSM: Printing -> Done] Печать успешно завершена.");
        }

        public void FailPrinting(Document document)
        {
            document.SetState(new ErrorState());
            Console.WriteLine("[FSM: Printing -> Error] Произошла ошибка во время печати.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: Printing] Нельзя сбросить документ во время печати.");
        }
    }
}
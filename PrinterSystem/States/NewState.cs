using System;
using PrinterSystem.Models;

namespace PrinterSystem.States
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            document.Mediator.Notify(document, "RequestPrint", document);
        }

        public void AddToQueue(Document document)
        {
            document.Mediator.Notify(document, "AddToQueue", document);
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine("[FSM: New] Нельзя завершить печать — документ ещё не печатается.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("[FSM: New] Нельзя зафиксировать ошибку — документ ещё не печатается.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: New] Документ уже в состоянии 'Новый', сброс не требуется.");
        }
    }
}
using System;
using PrinterSystem.Models;

namespace PrinterSystem.States
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine("[FSM: Done] Документ уже напечатан. Печать невозможна.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine("[FSM: Done] Нельзя добавить в очередь — документ уже напечатан.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine("[FSM: Done] Документ уже завершён.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine("[FSM: Done] Нельзя зафиксировать ошибку — документ уже напечатан.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine("[FSM: Done] Нельзя сбросить напечатанный документ.");
        }
    }
}
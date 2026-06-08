using PrinterSystem.Mediator;
using PrinterSystem.States;

namespace PrinterSystem.Models
{
    public class Document : Colleague
    {
        public string Title { get; }
        private IDocumentState State { get; set; }

        public Document(string title)
        {
            Title = title;
            State = new NewState();   // начальное состояние
        }

        public void SetState(IDocumentState state) => State = state;

        // Делегирование поведения текущему состоянию
        public void Print() => State.Print(this);
        public void AddToQueue() => State.AddToQueue(this);
        public void CompletePrinting() => State.CompletePrinting(this);
        public void FailPrinting() => State.FailPrinting(this);
        public void Reset() => State.Reset(this);
    }
}
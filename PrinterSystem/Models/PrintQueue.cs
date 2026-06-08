using System.Collections.Generic;
using PrinterSystem.Mediator;

namespace PrinterSystem.Models
{
    public class PrintQueue : Colleague
    {
        private Queue<Document> _queue = new Queue<Document>();

        public void EnqueueItem(Document document)
        {
            _queue.Enqueue(document);
            Mediator.Notify(this, "Enqueued", document);
        }

        public Document DequeueItem()
        {
            return _queue.Dequeue();
        }

        public bool IsEmpty => _queue.Count == 0;
    }
}
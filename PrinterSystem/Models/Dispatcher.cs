using PrinterSystem.Mediator;

namespace PrinterSystem.Models
{
    public class Dispatcher : Colleague
    {
        public void CommandProcessQueue()
        {
            Mediator.Notify(this, "ProcessQueue");
        }
    }
}
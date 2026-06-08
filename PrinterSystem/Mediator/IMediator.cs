using PrinterSystem.Models;

namespace PrinterSystem.Mediator
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document document = null);
    }
}
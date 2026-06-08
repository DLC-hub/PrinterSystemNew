namespace PrinterSystem.Mediator
{
    public abstract class Colleague
    {
        public IMediator Mediator { get; private set; }

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
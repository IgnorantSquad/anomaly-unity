namespace Anomaly
{
    public interface IEventListener
    {
        void Execute(Actor sender);
    }
}
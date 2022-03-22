namespace Anomaly.Temp
{
    public interface IEventListener
    {
        void Execute(Actor sender);
    }
}
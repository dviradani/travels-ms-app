namespace ActivitiesService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
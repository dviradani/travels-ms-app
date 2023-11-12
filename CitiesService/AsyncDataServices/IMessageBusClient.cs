using CitiesService.Dtos;

namespace CitiesService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewCity(CityPublishedDto cityPublishedDto);
    }
}
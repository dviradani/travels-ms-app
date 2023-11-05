using System.Text.Json;
using ActivitiesService.Data;
using ActivitiesService.Dtos;
using ActivitiesService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ActivitiesService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _secopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory secopeFactory, IMapper mapper)
        {
            _secopeFactory = secopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.CityPublished:
                    //TO DO 
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            System.Console.WriteLine("--> Determining event type");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType!.Event)
            {
                case "City_Published":
                System.Console.WriteLine("--> City_Published Event Detected");
                    return EventType.CityPublished;
                default:
                System.Console.WriteLine("--> Unknown Event Type: " + eventType);
                    return EventType.Undetermined;
            }
        }

        private void AddCity(string cityPublishedMessage)
        {
            using(var scope = _secopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IActivitiesRepo>();

                var cityPublishedDto = JsonSerializer.Deserialize<CityPublishedDto>(cityPublishedMessage);  

                try
                {
                    var city = _mapper.Map<City>(cityPublishedDto);
                    if(!repo.ExternalCityExists(city.ExternalID))
                    {
                        repo.CreateCity(city);
                        repo.SaveChanges();
                    }
                    else
                    {
                        System.Console.WriteLine("--> city already exists...");
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("--> Could not add city to DB: " + ex.Message);
                }
            }
        }
    }

    enum EventType
    {
        CityPublished,
        Undetermined
    }
}
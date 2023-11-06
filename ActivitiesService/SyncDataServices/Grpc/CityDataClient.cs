using ActivitiesService.Models;
using AutoMapper;
using CitiesService;
using Grpc.Net.Client;

namespace ActivitiesService.SyncDataServices.Grpc
{
    public class CityDataClient : ICityDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CityDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public IEnumerable<City> ReturnAllCities()
        {
            System.Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcCity"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcCity"]!);
            var client = new GrpcCity.GrpcCityClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllCities(request);
                return _mapper.Map<IEnumerable<City>>(reply.City);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"--> Could not call GRPC Server: {ex.Message}");
                return null!;
            }
        }
    }
}
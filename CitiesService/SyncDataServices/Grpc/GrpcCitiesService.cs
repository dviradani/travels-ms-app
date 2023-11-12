using AutoMapper;
using CitiesService.Data;
using Grpc.Core;

namespace CitiesService.SyncDataServices.Grpc
{
    public class GrpcCitiesService : GrpcCity.GrpcCityBase
    {
        private readonly ICityRepo _repo;
        private readonly IMapper _mapper;

        public GrpcCitiesService(ICityRepo repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override Task<CitiesResponse> GetAllCities(GetAllRequest request, ServerCallContext context)
        {
            var response = new CitiesResponse();
            var cities = _repo.GetAllCities();

            foreach(var city in cities)
            {
                response.City.Add(_mapper.Map<GrpcCityModel>(city));
            }

            return Task.FromResult(response);
        }
    }
}
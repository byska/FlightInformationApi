using System.Net;
using Entities;
using MediatR;
public class GetAllFlightsQueryRequest : IRequest<List<GetAllFlightsQueryResponse>>
{

}

public class GetAllFlightsQueryResponse
{
    public string FlightNumber { get; set; }
    public DateTime FlightDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public double Distance { get; set; }
    public FlightRouteResponse FlightRoute { get; set; }
    public VehicleTypeResponse VehicleType { get; set; }
    public SharedFlightResponse SharedFlight { get; set; }

}
public class FlightRouteResponse
{
    public AirportResponse SourceAirport { get; set; }

    public AirportResponse DestinationAirport { get; set; }
    public string RouteType { get; set; }

}

public class VehicleTypeResponse
{
    public string AircraftType { get; set; }
    public int SeatCount { get; set; }
    public string SeatPlan { get; set; }

    public int MaxPassengers { get; set; }
    public int MaxCrew { get; set; }
    public string StandardMenu { get; set; }
}
public class AirportResponse
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}
public class SharedFlightResponse
{
    public string PartnerFlightNumber { get; set; }
    public string PartnerCompany { get; set; }
    public Guid FlightId { get; set; }

}

public class GetAllFlightsHandler : IRequestHandler<GetAllFlightsQueryRequest, List<GetAllFlightsQueryResponse>>
{
    private readonly IFlightRepository _repo;

    public GetAllFlightsHandler(IFlightRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<GetAllFlightsQueryResponse>> Handle(GetAllFlightsQueryRequest request, CancellationToken cancellationToken)
    {
        var flights = await _repo.GetAllAsync(cancellationToken);
        return flights.Select(f => new GetAllFlightsQueryResponse
        {
            FlightNumber = f.FlightNumber.Value,
            FlightDateTime = f.FlightDateTime,
            Duration = f.Duration,
            Distance = f.Distance,

            FlightRoute = new FlightRouteResponse
            {
                SourceAirport = new AirportResponse
                {
                    Country = f.FlightRoute.SourceAirport.Country,
                    City = f.FlightRoute.SourceAirport.City,
                    Name = f.FlightRoute.SourceAirport.Name,
                    Code = f.FlightRoute.SourceAirport.Code
                },
                DestinationAirport = new AirportResponse
                {
                    Country = f.FlightRoute.DestinationAirport.Country,
                    City = f.FlightRoute.DestinationAirport.City,
                    Name = f.FlightRoute.DestinationAirport.Name,
                    Code = f.FlightRoute.DestinationAirport.Code
                },
                RouteType = f.FlightRoute.RouteType.ToString()
            },

            VehicleType = new VehicleTypeResponse
            {
                AircraftType = f.VehicleType.AircraftType.ToString(),
                SeatCount = f.VehicleType.SeatCount,
                SeatPlan = f.VehicleType.SeatPlan.ToString(),
                MaxPassengers = f.VehicleType.MaxPassengers,
                MaxCrew = f.VehicleType.MaxCrew,
                StandardMenu = f.VehicleType.StandardMenu
            },

            SharedFlight = new SharedFlightResponse
            {
                PartnerFlightNumber = f.SharedFlight.PartnerFlightNumber,
                PartnerCompany = f.SharedFlight.PartnerCompany,
                FlightId = f.SharedFlight.FlightId,

            }
        }).ToList();
    }
}

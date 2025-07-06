using System.Net;
using Entities;
using MediatR;
public class GetByIdFlightsQueryRequest : IRequest<GetByIdFlightsQueryResponse>
{
    public Guid Id { get; set; }

    public GetByIdFlightsQueryRequest(Guid ıd)
    {
        Id = ıd;
    }
}

public class GetByIdFlightsQueryResponse
{
    public string FlightNumber { get; set; }
    public DateTime FlightDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public double Distance { get; set; }
    public FlightRouteResponse FlightRoute { get; set; }
    public VehicleTypeResponse VehicleType { get; set; }
    public SharedFlightResponse SharedFlight { get; set; }

}

public class GetByIdFlightsHandler : IRequestHandler<GetByIdFlightsQueryRequest, GetByIdFlightsQueryResponse>
{
    private readonly IFlightRepository _repo;

    public GetByIdFlightsHandler(IFlightRepository repo)
    {
        _repo = repo;
    }

    public async Task<GetByIdFlightsQueryResponse> Handle(GetByIdFlightsQueryRequest request, CancellationToken cancellationToken)
    {
        var flights = await _repo.GetByIdAsync(request.Id,cancellationToken);
                if (flights is null) return null;               
        return new GetByIdFlightsQueryResponse
        {
            FlightNumber = flights.FlightNumber.Value,
            FlightDateTime = flights.FlightDateTime,
            Duration = flights.Duration,
            Distance = flights.Distance,

            FlightRoute = new FlightRouteResponse
            {
                SourceAirport = new AirportResponse
                {
                    Country = flights.FlightRoute.SourceAirport.Country,
                    City = flights.FlightRoute.SourceAirport.City,
                    Name = flights.FlightRoute.SourceAirport.Name,
                    Code = flights.FlightRoute.SourceAirport.Code
                },
                DestinationAirport = new AirportResponse
                {
                    Country = flights.FlightRoute.DestinationAirport.Country,
                    City = flights.FlightRoute.DestinationAirport.City,
                    Name = flights.FlightRoute.DestinationAirport.Name,
                    Code = flights.FlightRoute.DestinationAirport.Code
                },
                RouteType = flights.FlightRoute.RouteType.ToString()
            },

            VehicleType = new VehicleTypeResponse
            {
                AircraftType = flights.VehicleType.AircraftType.ToString(),
                SeatCount = flights.VehicleType.SeatCount,
                SeatPlan = flights.VehicleType.SeatPlan.ToString(),
                MaxPassengers = flights.VehicleType.MaxPassengers,
                MaxCrew = flights.VehicleType.MaxCrew,
                StandardMenu = flights.VehicleType.StandardMenu
            },

            SharedFlight = new SharedFlightResponse
            {
                PartnerFlightNumber = flights.SharedFlight.PartnerFlightNumber,
                PartnerCompany = flights.SharedFlight.PartnerCompany,
                FlightId = flights.SharedFlight.FlightId,

            }
        };
    }
}

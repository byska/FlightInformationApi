using Entities;
using FlightManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class FlightRepository : IFlightRepository
{
    private readonly FlightDbContext _flightContext;
    public FlightRepository(FlightDbContext flightContext) => _flightContext = flightContext;

    public async Task<IReadOnlyList<Flight>> GetAllAsync(CancellationToken ct)
    {
        return await _flightContext.Flights.AsNoTracking().ToListAsync(ct);

    }

    public async Task<Flight> GetByIdAsync(Guid id, CancellationToken ct)
    {
        Flight? flight = await _flightContext.Flights.Where(x => x.Id == id).FirstOrDefaultAsync(ct);
        return flight;
    }
    public async Task<Flight> GetByFlightNumberAsync(string flightNumber, CancellationToken ct)
    {
        Flight? flight = await _flightContext.Flights.Where(x => x.FlightNumber == flightNumber).FirstOrDefaultAsync(ct);
        return flight;
    }
}
using Entities;

public interface IFlightRepository
{
    Task<IReadOnlyList<Flight>> GetAllAsync(CancellationToken ct);
    Task<Flight> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Flight> GetByFlightNumberAsync(string flightNumber, CancellationToken ct);
}


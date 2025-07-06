using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetAllFlightsQueryRequest(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute]Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetByIdFlightsQueryRequest(id), cancellationToken);
        if (result == null) return NotFound();
        return Ok(result);
    }
    [HttpGet("{flightNumber}")]
    public async Task<IActionResult> Get([FromRoute]string flightNumber,CancellationToken cancellationToken= default)
    {
        var result = await _mediator.Send(new GetByFlightNumberFlightsQueryRequest(flightNumber),cancellationToken);
        if (result == null) return NotFound();
        return Ok(result);
    }
}

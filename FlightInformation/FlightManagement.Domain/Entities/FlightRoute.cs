using System;
using Entities;
using FlightManagement.Domain.Enums;


namespace Entities
{
    public class FlightRoute : EntityBase
    {
        public Guid SourceAirportId { get; set; }
        public Airport SourceAirport { get; set; }

        public Guid DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }
        public RouteType RouteType { get; set; }

        public FlightRoute()
        {
        }
    }
}
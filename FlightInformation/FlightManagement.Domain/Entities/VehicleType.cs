using System;
using FlightManagement.Domain.Enums;

namespace Entities
{
    public class VehicleType : EntityBase
    {
        public AircraftType AircraftType { get; set; }
        public int SeatCount { get; set; }
        public SeatPlan SeatPlan { get; set; }

        public int MaxPassengers { get; set; }
        public int MaxCrew { get; set; }
        public string StandardMenu { get; set; }

        public VehicleType()
        {
        }
    }
}
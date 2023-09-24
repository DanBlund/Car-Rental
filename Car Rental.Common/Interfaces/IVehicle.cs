using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegNumber { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public VehicleTypes VehicleType { get; init; }
    public int CostPerKm { get; set; }
    public int CostPerDay { get; set; }
    public bool Status { get; set; }

}

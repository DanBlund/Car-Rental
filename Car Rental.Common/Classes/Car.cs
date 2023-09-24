using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public string RegNumber { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public VehicleTypes VehicleType { get; init; }
    public int CostPerKm { get; set; }
    public int CostPerDay { get; set; }
    public bool Status { get; set; }

    public Car(string regNo, string make, int odo, VehicleTypes veType, int costKm, int costDay, bool status) =>
        (RegNumber, Make, Odometer, VehicleType, CostPerKm, CostPerDay, Status) = (regNo, make, odo, veType, costKm, costDay, status);

}

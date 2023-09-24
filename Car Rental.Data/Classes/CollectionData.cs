using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using System;
using System.Dynamic;
using System.Collections;
using Car_Rental.Common.Enums;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IVehicle> _vehicles = new();
    readonly List<ICustomer> _customers = new();
    readonly List<IBooking> _bookings = new();

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) +1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    List<ICustomer> IData.Customers => _customers;
    List<IVehicle> IData.Vehicles => _vehicles;
    List<IBooking> IData.Bookings => _bookings;

    public CollectionData() => SeedData();

    void SeedData()
    {
        _vehicles.Add(new Car(1, "ABC 123", "Volvo", 1000, Common.Enums.VehicleTypes.Sedan, 3, 100, BookingStatuses.Free));
        _vehicles.Add(new Car(2, "DEF 456", "Saab", 2000, Common.Enums.VehicleTypes.Combi, 5, 200, BookingStatuses.Free));
        _vehicles.Add(new Car(3, "GHI 789", "Fiat", 3000, Common.Enums.VehicleTypes.Van, 7, 300, BookingStatuses.Free));
        _vehicles.Add(new Motorcycle(4, "JKL 012", "Suzuki", 4000, Common.Enums.VehicleTypes.Motorcycle, 9, 400, BookingStatuses.Free));
        _vehicles.Add(new Motorcycle(5, "LMN 345", "Yamaha", 5000, Common.Enums.VehicleTypes.Motorcycle, 10, 500, BookingStatuses.Free));

        _customers.Add(new Customer(123456, "Pelle", "Skrälle"));
        _customers.Add(new Customer(789123, "Maja", "Kajja"));
        _customers.Add(new Customer(456789, "Kalle ", "Nalle"));

        //_bookings.Add(new Booking(1, "ABC 123", "John Snow", 500, 1000, new DateTime(2023, 09, 20), new DateTime(2023, 09, 24), 1500, BookingStatuses.Free));
        //_bookings.Add(new Booking(2, "DEF 456", "Arya Stark", 1000, 0, new DateTime(2023, 09, 19), default, 5000, BookingStatuses.Booked));
        //_bookings.Add(new Booking(3, "GHI 789", "Tyrion Lannister", 2800, 3000, new DateTime(2023, 09, 17), new DateTime(2023, 09, 19), 5000, BookingStatuses.Free));
    }  

    public List<T> GetList<T>(List<T> data)
    {
        return data.ToList();
    }
    public void Add<T>(List<T> data, T item)
    {
        data.Add(item);
    }
    public T? GetSingle<T>(List<T> data, Func<T, bool>? expression)
    {
        if(expression == null)
        {
            throw new ArgumentNullException();
        }
        return data.FirstOrDefault(expression);
    }
}

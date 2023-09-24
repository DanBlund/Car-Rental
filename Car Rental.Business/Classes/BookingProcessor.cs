using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Car_Rental.Common.Enums;
using Car_Rental.Data.Interfaces;
using Car_Rental.Business.Extensions;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData _data;

    // Constructor
    public BookingProcessor(IData data)
    {
        _data = data;
    }

    public List<ICustomer> CustomerGetter()
    {
        return _data.GetList<ICustomer>(_data.Customers);
    }
    public List<IVehicle> VehicleGetter()
    {
        return _data.GetList<IVehicle>(_data.Vehicles);
    }
    public List<IBooking> BookingGetter()
    {
        return _data.GetList<IBooking>(_data.Bookings);
    }
    public void AddCustomer(int? ssn, string fname, string lname)
    {
        int ssn2 = (int)ssn!;
        _data.Add(_data.Customers, new Customer(ssn2, fname, lname));
    }
    public void AddVehicle(string regNo, string make, int? odo, VehicleTypes veType, int? costKm, int? costDay)
    {
        if(odo == null || costKm == null || costDay == null)       
            return;

        int id = _data.NextVehicleId;
        int odo2 = (int)odo;
        int costKm2 = (int)costKm;
        int costDay2 = (int)costDay;
        if (veType == VehicleTypes.Motorcycle)
        {
            _data.Add(_data.Vehicles, new Motorcycle(id, regNo, make, odo2, veType, costKm2, costDay2, BookingStatuses.Free));
        }
        else
        {
            _data.Add(_data.Vehicles, new Car(id, regNo, make, odo2, veType, costKm2, costDay2, BookingStatuses.Free));
        }
    }
    public async Task AddBooking(int vehicleId, string regNo, string cust, int kmRent, int? kmReturn, DateTime rented, DateTime returned, int? cost, BookingStatuses status)
    {
        if (cust == null || cust == string.Empty)
            return;
        await Task.Delay(5000);
        int id = _data.NextBookingId;
        _data.Add(_data.Bookings, new Booking(id, regNo, cust, kmRent, kmReturn, rented, returned, cost, status));
        var vehicle = _data.GetSingle(_data.Vehicles, (p => p.Id == vehicleId));
        vehicle!.BookingStatus = BookingStatuses.Booked;  
    }
    public void ReturnBooking(int bookId, string vehicleReg, int? odoAtReturn)
    {
        var booking = _data.GetSingle(_data.Bookings, (b => b.Id == bookId));
        if (odoAtReturn < booking!.KmRented || odoAtReturn == null)
            return;

        booking.KmReturned = odoAtReturn;
        booking.Returned = BookingExtensions.GetLaterDate();
        booking.BookingStatus = BookingStatuses.Free;

        var vehicle = _data.GetSingle(_data.Vehicles, (v => v.RegNumber == vehicleReg));
        vehicle!.BookingStatus = BookingStatuses.Free;
        vehicle.Odometer = (int)odoAtReturn;
    }
}

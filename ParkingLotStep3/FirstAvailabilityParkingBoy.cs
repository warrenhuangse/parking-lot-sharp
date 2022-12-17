namespace ParkingLotStep3;

public class FirstAvailabilityParkingBoy : ParkingBoy
{
    public FirstAvailabilityParkingBoy(ParkingLot lot1, ParkingLot lot2) : base(lot1, lot2)
    {
    }

    public override void Park(Car car)
    {
        if (Lot1.HasCar(car) || Lot2.HasCar(car))
            throw new ArgumentException("Car " + car + " has been parked");

        if (!Lot1.IsFull())
        {
            Lot1.Park(car);
            return;
        }

        if (!Lot2.IsFull())
        {
            Lot2.Park(car);
            return;
        }

        throw new Exception("No lot for more cars");
    }
}
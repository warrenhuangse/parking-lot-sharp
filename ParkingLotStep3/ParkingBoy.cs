namespace ParkingLotStep3;

public abstract class ParkingBoy
{
    protected readonly ParkingLot Lot1;
    protected readonly ParkingLot Lot2;

    protected ParkingBoy(ParkingLot lot1, ParkingLot lot2)
    {
        Lot1 = lot1;
        Lot2 = lot2;
    }

    public abstract void Park(Car car);

    public void Unpark(Car car)
    {
        if (Lot1.HasCar(car))
        {
            Lot1.Unpark(car);
            return;
        }

        if (Lot2.HasCar(car))
        {
            Lot2.Unpark(car);
            return;
        }

        throw new ArgumentException("Failed to unpark car " + car);
    }
}
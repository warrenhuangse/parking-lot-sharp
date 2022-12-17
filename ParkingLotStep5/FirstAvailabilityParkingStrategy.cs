namespace ParkingLotStep5;

public class FirstAvailabilityParkingStrategy : IParkingStrategy
{
    public IParkable? GetAvailableLot(IParkable lot1, IParkable lot2)
    {
        if (!lot1.IsFull()) return lot1;

        if (!lot2.IsFull()) return lot2;

        return null;
    }
}
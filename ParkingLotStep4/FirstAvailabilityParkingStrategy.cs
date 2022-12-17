namespace ParkingLotStep4;

public class FirstAvailabilityParkingStrategy : IParkingStrategy
{
    public ParkingLot? GetAvailableLot(ParkingLot lot1, ParkingLot lot2)
    {
        if (!lot1.IsFull()) return lot1;

        if (!lot2.IsFull()) return lot2;

        return null;
    }
}
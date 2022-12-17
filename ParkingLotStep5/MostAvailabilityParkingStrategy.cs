namespace ParkingLotStep5;

public class MostAvailabilityParkingStrategy : IParkingStrategy
{
    public IParkable? GetAvailableLot(IParkable lot1, IParkable lot2)
    {
        var availability1 = lot1.GetAvailability();
        var availability2 = lot2.GetAvailability();

        if (availability1 <= 0 && availability2 <= 0) return null;

        if (availability1 >= availability2)
        {
            return lot1;
        }
        else
        {
            return lot2;
        }
    }
}
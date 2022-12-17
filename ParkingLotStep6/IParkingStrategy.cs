namespace ParkingLotStep6;

public interface IParkingStrategy
{
    IParkable? GetAvailableLot(IParkable lot1, IParkable lot2);
}
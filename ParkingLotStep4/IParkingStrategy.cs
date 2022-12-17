namespace ParkingLotStep4;

public interface IParkingStrategy
{
    ParkingLot? GetAvailableLot(ParkingLot lot1, ParkingLot lot2);
}
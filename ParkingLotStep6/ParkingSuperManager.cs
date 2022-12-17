namespace ParkingLotStep6;

public class ParkingSuperManager : ParkingRole
{
    public ParkingSuperManager(IParkable parkable1, IParkable parkable2, IParkingStrategy strategy)
        : base(parkable1, parkable2, strategy)
    {
    }
}
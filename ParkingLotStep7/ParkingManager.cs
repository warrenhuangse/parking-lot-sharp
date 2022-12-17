namespace ParkingLotStep7;

public class ParkingManager : ParkingRole
{
    public ParkingManager(IParkable parkable1, IParkable parkable2, IParkingStrategy strategy)
        : base(parkable1, parkable2, strategy)
    {
    }

    protected override string Name => "ParkingManager";
}